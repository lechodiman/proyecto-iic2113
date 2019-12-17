using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Core.Flash;
using Core.Flash.Extensions;
using Core.Flash.Model;
using Core.Flash.Mvc;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using proyecto_iic2113.Data;
using proyecto_iic2113.Helpers;
using proyecto_iic2113.Models;

namespace proyecto_iic2113.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        private IFlasher _flasher;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext context, IFlasher f, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _flasher = f;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Conferences.Include(c => c.Venue).Take(3);
            var venues = _context.Venues.Take(3);
            ViewBag.venues = venues;
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Evaluation()
        {
            var currentUser = await GetCurrentUserAsync();
            if (currentUser == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var averageCalculator = new AverageCalculator(_context);
            var averageRating = await averageCalculator.CalculateUserTalkAverageAsync(currentUser.Id);
            ViewBag.averageRating = averageRating;

            var filterTalk = await _context.TalkLecturers
                .Where(talkLecturer => talkLecturer.Lecturer.Id == currentUser.Id)
                .Select(talkLecturer => talkLecturer.Talk)
                .ToListAsync();

            var talksAverageReviews = filterTalk
                .Select(async talk => await averageCalculator.CalculateEventAverageAsync(talk.Id))
                .Select(task => task.Result)
                .ToList();

            ViewBag.talksAverageReviews = talksAverageReviews;
            ViewBag.talks = filterTalk;
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Notifications()
        {
            var user = await GetCurrentUserAsync();
            var userId = user?.Id;
            var applicationDbContext = _context.Notifications
                .Where(c => c.Receiver.Id == userId)
                .Include(c => c.Conference)
                .Include(c => c.Event);
            ViewBag.userId = userId;
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> DeleteNotification(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notification = await _context.Notifications
                .Include(r => r.Receiver)
                .Include(r => r.Conference)
                .Include(r => r.Event)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notification == null)
            {
                return NotFound();
            }

            return View(notification);
        }

        // POST: Review/Delete/5
        [HttpPost, ActionName("DeleteNotification")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            _context.Notifications.Remove(notification);
            await _context.SaveChangesAsync();
            return RedirectToAction("Notifications", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
