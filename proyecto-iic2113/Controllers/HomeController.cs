using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using proyecto_iic2113.Data;
using proyecto_iic2113.Models;

namespace proyecto_iic2113.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
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

        public async Task<IActionResult> Notifications()
        {
            var applicationDbContext = _context.Notifications.Include(c => c.Conference).Include(c => c.Event).Include(c => c.Receiver);
            var user = await GetCurrentUserAsync();
            var userId = user?.Id;
            ViewBag.UserId = userId;
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["ConferenceId"] = new SelectList(_context.Conferences, "Id", "Name");
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Email");
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Name");
            return View();

        }

        // POST: Launch/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,Id,Body,Receiver,ConferenceId,EventId")] Notifications notification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConferenceId"] = new SelectList(_context.Conferences, "Id", "Name", notification.ConferenceId);
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Name", notification.EventId);
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Email", notification.ApplicationUserId);
            return View(notification);
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
