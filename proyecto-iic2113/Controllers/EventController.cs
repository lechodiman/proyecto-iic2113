using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Core.Flash;

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
        private readonly IFlasher _flasher;

        public EventController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IFlasher flasher)
        {
            _flasher = flasher;
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
                _flasher.Flash("Danger", "You must attend the conference to attend an event.");
                return Redirect(Request.Headers["Referer"].ToString());
            }

            if (eventAttendees.Count + 1 > currentEvent.Capacity)
            {
                _flasher.Flash("Danger", "Event is already full.");
                return Redirect(Request.Headers["Referer"].ToString());
            }

            if (isUserAttendingEvent)
            {
                _flasher.Flash("Danger", "You are already attending this event");
                return Redirect(Request.Headers["Referer"].ToString());
            }

            var eventUserAttendee = new EventUserAttendee();
            eventUserAttendee.ApplicationUserId = currentUser.Id;
            eventUserAttendee.EventId = currentEvent.Id;

            _context.EventUserAttendees.Add(eventUserAttendee);
            await _context.SaveChangesAsync();

            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpGet]
        public IActionResult CreateNotification(int? id)
        {
            ViewBag.EventId = id;
            return View();
        }

        // POST: Launch/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNotification([Bind("Body,EventId")] Notifications notification)
        {
            var attendees = await _context.EventUserAttendees.Where(s => s.EventId == notification.EventId).ToListAsync();
            ViewBag.Attendees = attendees;
            var eventid = await _context.Events.Where(e => e.Id == notification.EventId).ToListAsync();

            if (ModelState.IsValid)
            {
                foreach (var attendee in ViewBag.Attendees)
                {
                    var userNotification = new Notifications();
                    userNotification.ApplicationUserId = attendee.ApplicationUserId;
                    userNotification.ConferenceId = eventid[0].ConferenceId;
                    userNotification.EventId = notification.EventId;
                    userNotification.Body = notification.Body;
                    userNotification.Date = DateTime.Now;
                    _context.Notifications.Add(userNotification);
                    await _context.SaveChangesAsync();

                }
                return Redirect(Request.Headers["Referer"].ToString());
            }
            return View(notification);
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
