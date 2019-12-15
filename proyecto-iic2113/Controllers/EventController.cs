using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using proyecto_iic2113.Data;
using proyecto_iic2113.Helpers;
using proyecto_iic2113.Models;

namespace proyecto_iic2113.Controllers
{
    public class EventController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public EventController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var numberOfEventsPerType = 3;

            var parties = _context.Parties
                .Include(party => party.Conference)
                .Take(numberOfEventsPerType);
            var workshops = _context.Workshops
                .Include(workshop => workshop.Conference)
                .Take(numberOfEventsPerType);
            var launches = _context.Launches
                .Include(launch => launch.Conference)
                .Take(numberOfEventsPerType);
            var chats = _context.Chat
                .Include(chat => chat.Conference)
                .Take(numberOfEventsPerType);
            var talks = _context.Talks
                .Include(talk => talk.Conference)
                .Take(numberOfEventsPerType);

            ViewBag.parties = await parties.ToListAsync();
            ViewBag.workshops = await workshops.ToListAsync();
            ViewBag.launches = await launches.ToListAsync();
            ViewBag.chats = await chats.ToListAsync();
            ViewBag.talks = await talks.ToListAsync();

            return View();
        }

        public async Task<IActionResult> Dashboard(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews
                .Where(r => r.EventId == id)
                .ToListAsync();

            var averageCalculator = new AverageCalculator(_context);
            var averageRating = await averageCalculator.CalculateEventAverageAsync(id);
            ViewBag.averageRating = averageRating;
            ViewBag.numberOfReviews = reviews.Count;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AttendEvent(int id)
        {
            var currentEvent = await _context.Events.FindAsync(id);
            _context.Entry(currentEvent).Reference(e => e.Conference).Load();

            var currentUser = await GetCurrentUserAsync();
            var attendanceHelper = new AttendanceHelper(_context);

            var eventAttendees = await _context.EventUserAttendees
                .Where(t => t.EventId == id)
                .ToListAsync();

            var isAttendingConference = await attendanceHelper.IsUserAttendingConference(currentUser, currentEvent.Conference);

            var isUserAttendingEvent = await attendanceHelper.IsUserAttendingEvent(currentUser, currentEvent);

            if (!isAttendingConference)
            {
                return Redirect(Request.Headers["Referer"].ToString());
            }

            if (eventAttendees.Count + 1 > currentEvent.Capacity)
            {
                // TODO: Show error
                return Redirect(Request.Headers["Referer"].ToString());
            }

            if (isUserAttendingEvent)
            {
                ModelState.AddModelError(string.Empty, "You are already attending this conference");

                return Redirect(Request.Headers["Referer"].ToString());
            }

            var eventUserAttendee = new EventUserAttendee();
            eventUserAttendee.ApplicationUserId = currentUser.Id;
            eventUserAttendee.EventId = currentEvent.Id;

            _context.EventUserAttendees.Add(eventUserAttendee);
            await _context.SaveChangesAsync();

            return Redirect(Request.Headers["Referer"].ToString());
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
