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
    public class TalkLecturerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TalkLecturerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TalkLecturer
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TalkLecturer.Include(t => t.Lecturer).Include(t => t.Talk);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TalkLecturer/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talkLecturer = await _context.TalkLecturer
                .Include(t => t.Lecturer)
                .Include(t => t.Talk)
                .FirstOrDefaultAsync(m => m.TalkId == id);
            if (talkLecturer == null)
            {
                return NotFound();
            }

            return View(talkLecturer);
        }

        // GET: TalkLecturer/Create
        public async Task<IActionResult> Create(int? id)
        {
            var talk = await _context.Talks.FindAsync(id);
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Email");
            ViewBag.Talk = talk;
            return View();
        }

        // POST: TalkLecturer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationUserId,TalkId")] TalkLecturer talkLecturer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(talkLecturer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Talk", new { id = talkLecturer.TalkId });
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Email", talkLecturer.ApplicationUserId);
            return View(talkLecturer);
        }

        // GET: TalkLecturer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talkLecturer = await _context.TalkLecturer.FindAsync(id);
            if (talkLecturer == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", talkLecturer.ApplicationUserId);
            ViewData["TalkId"] = new SelectList(_context.Talks, "Id", "Discriminator", talkLecturer.TalkId);
            return View(talkLecturer);
        }

        // POST: TalkLecturer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicationUserId,TalkId")] TalkLecturer talkLecturer)
        {
            if (id != talkLecturer.TalkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(talkLecturer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TalkLecturerExists(talkLecturer.TalkId))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", talkLecturer.ApplicationUserId);
            ViewData["TalkId"] = new SelectList(_context.Talks, "Id", "Discriminator", talkLecturer.TalkId);
            return View(talkLecturer);
        }

        // GET: TalkLecturer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talkLecturer = await _context.TalkLecturer
                .Include(t => t.Lecturer)
                .Include(t => t.Talk)
                .FirstOrDefaultAsync(m => m.TalkId == id);
            if (talkLecturer == null)
            {
                return NotFound();
            }

            return View(talkLecturer);
        }

        // POST: TalkLecturer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var talkLecturer = await _context.TalkLecturer.FindAsync(id);
            _context.TalkLecturer.Remove(talkLecturer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TalkLecturerExists(int id)
        {
            return _context.TalkLecturer.Any(e => e.TalkId == id);
        }
    }
}
