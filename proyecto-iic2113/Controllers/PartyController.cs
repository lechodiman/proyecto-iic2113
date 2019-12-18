using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    public class PartyController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PartyController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Party
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Parties.Include(p => p.Conference).ThenInclude(c => c.Organizer);
            var user = await GetCurrentUserAsync();
            var userId = user?.Id;
            ViewBag.UserId = userId;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Party/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var party = await _context.Parties
                .Include(p => p.Room)
                .Include(p => p.Conference)
                .ThenInclude(conference => conference.Organizer)
                .FirstOrDefaultAsync(m => m.Id == id);

            var eventAttendees = await _context.EventUserAttendees
                .Where(t => t.EventId == id)
                .ToListAsync();
            ViewBag.numberOfAttendees = eventAttendees.Count;

            var user = await GetCurrentUserAsync();
            var userId = user?.Id;
            ViewBag.UserId = userId;

            var attendanceHelper = new AttendanceHelper(_context);
            ViewBag.isUserAttendingEvent = user != null ? await attendanceHelper.IsUserAttendingEvent(user, party) : false;

            if (party == null)
            {
                return NotFound();
            }
            return View(party);
        }

        // GET: Party/Create
        public IActionResult Create(int id)
        {
            ViewData["ConferenceId"] = new SelectList(_context.Conferences, "Id", "Name");
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name");
            ViewBag.ConferenceId = id;
            return View();
        }

        // POST: Party/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HasOpenBar,Name,StartDate,EndDate,Description,ConferenceId,Capacity,RoomId")] Party party)
        {
            if (ModelState.IsValid)
            {
                _context.Add(party);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Conference", new { id = party.ConferenceId });
            }
            ViewData["ConferenceId"] = new SelectList(_context.Conferences, "Id", "Name", party.ConferenceId);
            return View(party);
        }

        // GET: Party/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var party = await _context.Parties
                .Include(p => p.Conference)
                .ThenInclude(conference => conference.Organizer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (party == null)
            {
                return NotFound();
            }
            var user = await GetCurrentUserAsync();
            if (user.Id != party.Conference.Organizer.Id)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConferenceId"] = new SelectList(_context.Conferences, "Id", "Name", party.ConferenceId);
            return View(party);
        }

        // POST: Party/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HasOpenBar,Id,Name,StartDate,EndDate,Description,ConferenceId,Capacity")] Party party)
        {
            if (id != party.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(party);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartyExists(party.Id))
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
            ViewData["ConferenceId"] = new SelectList(_context.Conferences, "Id", "Name", party.ConferenceId);
            return View(party);
        }

        // GET: Party/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var party = await _context.Parties
                .Include(p => p.Conference)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (party == null)
            {
                return NotFound();
            }

            return View(party);
        }

        // POST: Party/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var party = await _context.Parties.FindAsync(id);
            _context.Parties.Remove(party);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartyExists(int id)
        {
            return _context.Parties.Any(e => e.Id == id);
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
