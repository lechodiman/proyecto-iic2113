using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using proyecto_iic2113.Data;
using proyecto_iic2113.Models;

namespace proyecto_iic2113.Controllers
{
    public class WorkshopExhibitorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkshopExhibitorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WorkshopExhibitor
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.WorkshopExhibitor.Include(w => w.Exhibitor).Include(w => w.Workshop);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: WorkshopExhibitor/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workshopExhibitor = await _context.WorkshopExhibitor
                .Include(w => w.Exhibitor)
                .Include(w => w.Workshop)
                .FirstOrDefaultAsync(m => m.WorkshopId == id);
            if (workshopExhibitor == null)
            {
                return NotFound();
            }

            return View(workshopExhibitor);
        }

        // GET: WorkshopExhibitor/Create
        public async Task<IActionResult> Create(int? id)
        {
            var workshop = await _context.Workshops.FindAsync(id);
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Email");
            ViewBag.Workshop = workshop;

            return View();
        }

        // POST: WorkshopExhibitor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationUserId,WorkshopId")] WorkshopExhibitor workshopExhibitor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workshopExhibitor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Workshop", new { id = workshopExhibitor.WorkshopId });
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Email", workshopExhibitor.ApplicationUserId);
            return View(workshopExhibitor);
        }

        // GET: WorkshopExhibitor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workshopExhibitor = await _context.WorkshopExhibitor.FindAsync(id);
            if (workshopExhibitor == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", workshopExhibitor.ApplicationUserId);
            ViewData["WorkshopId"] = new SelectList(_context.Workshops, "Id", "Discriminator", workshopExhibitor.WorkshopId);
            return View(workshopExhibitor);
        }

        // POST: WorkshopExhibitor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicationUserId,WorkshopId")] WorkshopExhibitor workshopExhibitor)
        {
            if (id != workshopExhibitor.WorkshopId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workshopExhibitor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkshopExhibitorExists(workshopExhibitor.WorkshopId))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", workshopExhibitor.ApplicationUserId);
            ViewData["WorkshopId"] = new SelectList(_context.Workshops, "Id", "Discriminator", workshopExhibitor.WorkshopId);
            return View(workshopExhibitor);
        }

        // GET: WorkshopExhibitor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workshopExhibitor = await _context.WorkshopExhibitor
                .Include(w => w.Exhibitor)
                .Include(w => w.Workshop)
                .FirstOrDefaultAsync(m => m.WorkshopId == id);
            if (workshopExhibitor == null)
            {
                return NotFound();
            }

            return View(workshopExhibitor);
        }

        // POST: WorkshopExhibitor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workshopExhibitor = await _context.WorkshopExhibitor.FindAsync(id);
            _context.WorkshopExhibitor.Remove(workshopExhibitor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkshopExhibitorExists(int id)
        {
            return _context.WorkshopExhibitor.Any(e => e.WorkshopId == id);
        }
    }
}
