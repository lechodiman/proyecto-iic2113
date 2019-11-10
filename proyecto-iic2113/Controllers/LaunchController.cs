using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proyecto_iic2113.Data;
using proyecto_iic2113.Models;

namespace proyecto_iic2113.Controllers
{
    public class LaunchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LaunchController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Launch
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Launches.Include(l => l.Conference);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Launch/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var launch = await _context.Launches
                .Include(l => l.Conference)
                .Include(l => l.Menus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (launch == null)
            {
                return NotFound();
            }

            return View(launch);
        }

        // GET: Launch/Create
        public IActionResult Create()
        {
            ViewData["ConferenceId"] = new SelectList(_context.Conferences, "Id", "Name");
            return View();
        }

        // POST: Launch/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IsAllYouCanEat,Id,Name,StartDate,EndDate,Description,ConferenceId")] Launch launch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(launch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConferenceId"] = new SelectList(_context.Conferences, "Id", "Name", launch.ConferenceId);
            return View(launch);
        }

        // GET: Launch/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var launch = await _context.Launches.FindAsync(id);
            if (launch == null)
            {
                return NotFound();
            }
            ViewData["ConferenceId"] = new SelectList(_context.Conferences, "Id", "Name", launch.ConferenceId);
            return View(launch);
        }

        // POST: Launch/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IsAllYouCanEat,Id,Name,StartDate,EndDate,Description,ConferenceId")] Launch launch)
        {
            if (id != launch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(launch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaunchExists(launch.Id))
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
            ViewData["ConferenceId"] = new SelectList(_context.Conferences, "Id", "Name", launch.ConferenceId);
            return View(launch);
        }

        // GET: Launch/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var launch = await _context.Launches
                .Include(l => l.Conference)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (launch == null)
            {
                return NotFound();
            }

            return View(launch);
        }

        // POST: Launch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var launch = await _context.Launches.FindAsync(id);
            _context.Launches.Remove(launch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaunchExists(int id)
        {
            return _context.Launches.Any(e => e.Id == id);
        }
    }
}
