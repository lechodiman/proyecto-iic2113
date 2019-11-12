using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proyecto_iic2113.Data;
using proyecto_iic2113.Models;
using Microsoft.AspNetCore.Identity;

namespace proyecto_iic2113.Controllers
{
    public class WorkshopController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public WorkshopController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Workshop
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Workshops.Include(w => w.Conference).ThenInclude(c => c.Organizer);
            var user = await GetCurrentUserAsync();
            var userId = user?.Id;
            ViewBag.UserId = userId;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Workshop/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workshop = await _context.Workshops
                .Include(w => w.Conference)
                .ThenInclude(conference => conference.Organizer)
                .FirstOrDefaultAsync(m => m.Id == id);

            var user = await GetCurrentUserAsync();
            var userId = user?.Id;
            ViewBag.UserId = userId;
            
            if (workshop == null)
            {
                return NotFound();
            }

            return View(workshop);
        }

        // GET: Workshop/Create
        public IActionResult Create()
        {
            ViewData["ConferenceId"] = new SelectList(_context.Conferences, "Id", "Name");
            return View();
        }

        // POST: Workshop/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,StartDate,EndDate,Description,ConferenceId")] Workshop workshop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workshop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConferenceId"] = new SelectList(_context.Conferences, "Id", "Name", workshop.ConferenceId);
            return View(workshop);
        }

        // GET: Workshop/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workshop = await _context.Workshops.FindAsync(id);
            if (workshop == null)
            {
                return NotFound();
            }
            ViewData["ConferenceId"] = new SelectList(_context.Conferences, "Id", "Name", workshop.ConferenceId);
            return View(workshop);
        }

        // POST: Workshop/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,StartDate,EndDate,Description,ConferenceId")] Workshop workshop)
        {
            if (id != workshop.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workshop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkshopExists(workshop.Id))
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
            ViewData["ConferenceId"] = new SelectList(_context.Conferences, "Id", "Name", workshop.ConferenceId);
            return View(workshop);
        }

        // GET: Workshop/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workshop = await _context.Workshops
                .Include(w => w.Conference)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workshop == null)
            {
                return NotFound();
            }

            return View(workshop);
        }

        // POST: Workshop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workshop = await _context.Workshops.FindAsync(id);
            _context.Workshops.Remove(workshop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkshopExists(int id)
        {
            return _context.Workshops.Any(e => e.Id == id);
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
