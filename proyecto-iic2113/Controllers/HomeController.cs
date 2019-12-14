using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using proyecto_iic2113.Data;
using proyecto_iic2113.Models;
using proyecto_iic2113.Helpers;

namespace proyecto_iic2113.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
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
