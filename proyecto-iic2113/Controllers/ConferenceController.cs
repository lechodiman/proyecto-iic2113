using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    public class ConferenceController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ConferenceController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Conference
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Conferences.Include(c => c.Venue).Include(c => c.Organizer);
            var user = await GetCurrentUserAsync();
            var userId = user?.Id;
            ViewBag.UserId = userId;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Conference/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conference = await _context.Conferences
                .Include(c => c.Organizer)
                .Include(c => c.Sponsors)
                .Include(c => c.Venue)
                .Include(c => c.Launches)
                .Include(c => c.Workshops)
                .Include(c => c.Parties)
                .Include(c => c.Talks)
                .Include(c => c.Chats)
                .Include(c => c.ConferenceUserAttendees)
                .ThenInclude(conferenceUserAttendee => conferenceUserAttendee.UserAttendee)
                .FirstOrDefaultAsync(m => m.Id == id);

            var sponsors = await _context.Sponsors.Where(s => s.ConferenceId == id).ToListAsync();
            var attendees = await _context.ConferenceUserAttendees.Where(s => s.ConferenceId == id).ToListAsync();

            ViewBag.Sponsors = sponsors;
            ViewBag.Attendees = attendees;

            var chats = await _context.Chat.Where(e => e.ConferenceId == id).ToListAsync();
            var parties = await _context.Parties.Where(e => e.ConferenceId == id).ToListAsync();
            var workshops = await _context.Workshops.Where(e => e.ConferenceId == id).ToListAsync();
            var launches = await _context.Launches.Where(e => e.ConferenceId == id).ToListAsync();
            var talks = await _context.Talks.Where(e => e.ConferenceId == id).ToListAsync();

            ViewBag.Chats = chats;
            ViewBag.Parties = parties;
            ViewBag.Workshops = workshops;
            ViewBag.Launches = launches;
            ViewBag.Talks = talks;

            var user = await GetCurrentUserAsync();
            var userId = user?.Id;
            ViewBag.UserId = userId;

            if (conference == null)
            {
                return NotFound();
            }

            return View(conference);
        }

        // GET: Conference/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["VenueId"] = new SelectList(_context.Venues, "Id", "Name");
            ViewData["FranchiseId"] = new SelectList(_context.Venues, "Id", "Name");
            return View();
        }

        // POST: Conference/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,DateTime,EndDate,VenueId,FranchiseId")] Conference conference)
        {
            ApplicationUser currentUser = await GetCurrentUserAsync();
            conference.Organizer = currentUser;
            if (ModelState.IsValid)
            {
                _context.Add(conference);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VenueId"] = new SelectList(_context.Venues, "Id", "Name", conference.VenueId);
            ViewData["FranchiseId"] = new SelectList(_context.Venues, "Id", "Name", conference.FranchiseId);
            return View(conference);
        }

        // GET: Conference/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conference = await _context.Conferences
                .Include(c => c.Organizer)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (conference == null)
            {
                return NotFound();
            }

            var user = await GetCurrentUserAsync();

            if (user.Id != conference.Organizer.Id)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewData["VenueId"] = new SelectList(_context.Venues, "Id", "Name", conference.VenueId);
            return View(conference);
        }

        // POST: Conference/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,DateTime,VenueId")] Conference conference)
        {
            if (id != conference.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conference);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConferenceExists(conference.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["VenueId"] = new SelectList(_context.Venues, "Id", "Name", conference.VenueId);
            return View(conference);
        }

        // GET: Conference/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conference = await _context.Conferences
                .Include(c => c.Venue)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conference == null)
            {
                return NotFound();
            }

            return View(conference);
        }

        // POST: Conference/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conference = await _context.Conferences.FindAsync(id);
            _context.Conferences.Remove(conference);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AttendConference(int id)
        {

            var conference = await _context.Conferences.FindAsync(id);
            var currentUser = await GetCurrentUserAsync();

            var existingConferenceUserAttendee = await _context.ConferenceUserAttendees.SingleOrDefaultAsync(m => m.ConferenceId == conference.Id && m.ApplicationUserId == currentUser.Id);

            // Check if user is already attending this conference
            if (existingConferenceUserAttendee != null)
            {
                ModelState.AddModelError(string.Empty, "You are already attending this conference");
                // TODO: Show this error to a view
            }
            else
            {
                var conferenceUserAttendee = new ConferenceUserAttendee();
                conferenceUserAttendee.UserAttendee = currentUser;
                conferenceUserAttendee.Conference = conference;

                _context.ConferenceUserAttendees.Add(conferenceUserAttendee);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Details), new { id = id });
        }

        private bool ConferenceExists(int id)
        {
            return _context.Conferences.Any(e => e.Id == id);
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

    }
}
