using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto_iic2113.Data;
using proyecto_iic2113.Models;
using Microsoft.AspNetCore.Identity;
using proyecto_iic2113.Helpers;

namespace proyecto_iic2113.Controllers
{
    public class FranchiseController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FranchiseController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Franchise/Dashboard
        public async Task<IActionResult> MyEvaluation()
        {
            var currentUser = await GetCurrentUserAsync();
            if (currentUser == null){
                // TODO: should redirect to home page
                return RedirectToAction(nameof(Index));
            }

            ViewBag.UserId = currentUser?.Id;
            var averageCalculator = new AverageCalculator(_context);
            var averageRating = await averageCalculator.CalculateFranchisesAverageAsync(currentUser.Id);
            ViewBag.averageRating = averageRating;

            var franchises = await _context.Franchises
                .Where(franchise => franchise.Organizer.Id == currentUser.Id)
                .ToListAsync();

            var franchisesAverageReviews = franchises
                .Select(async franchise => await averageCalculator.CalculateFranchiseAverageAsync(franchise.Id))
                .Select(task => task.Result)
                .ToList();

            ViewBag.franchisesAverageReviews = franchisesAverageReviews;
            ViewBag.franchises = franchises;
            return View();
        }

        // GET: Franchise/Dashboard/1
        public async Task<IActionResult> Dashboard(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var franchise = await _context.Franchises
                .FirstOrDefaultAsync(m => m.Id == id);

            if (franchise == null)
            {
                return NotFound();
            }

            var conferences = await _context.Conferences
                .Where(conference => conference.FranchiseId == id)
                .ToListAsync();

            var averageCalculator = new AverageCalculator(_context);
            var averageRating = await averageCalculator.CalculateFranchiseAverageAsync(id);
            ViewBag.averageRating = averageRating;

            var conferencesAverageReviews = conferences
                .Select(async conference => await averageCalculator.CalculateConferenceAverageAsync(conference.Id))
                .Select(task => task.Result)
                .ToList();

            ViewBag.conferencesAverageReviews = conferencesAverageReviews;
            ViewBag.conferences = conferences;

            return View(franchise);
        }

        // GET: Franchise
        public async Task<IActionResult> Index()
        {
            return View(await _context.Franchise.ToListAsync());
        }

        // GET: Franchise/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var franchise = await _context.Franchise
                .Include(c => c.Conferences)
                .Include(f => f.Organizer)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (franchise == null)
            {
                return NotFound();
            }

            var conferences = await _context.Conferences.Where(e => e.FranchiseId == id).ToListAsync();
            ViewBag.Conferences = conferences;


            return View(franchise);
        }

        // GET: Franchise/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Franchise/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Orga")] Franchise franchise)
        {
            ApplicationUser currentUser = await GetCurrentUserAsync();
            franchise.Organizer = currentUser;
            if (ModelState.IsValid)
            {
                _context.Add(franchise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(franchise);
        }

        // GET: Franchise/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var franchise = await _context.Franchise.FindAsync(id);
            if (franchise == null)
            {
                return NotFound();
            }
            return View(franchise);
        }

        // POST: Franchise/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Franchise franchise)
        {
            if (id != franchise.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {   
                    var currentUser = await GetCurrentUserAsync();
                    franchise.Organizer = currentUser;
                    _context.Update(franchise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FranchiseExists(franchise.Id))
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
            return View(franchise);
        }

        // GET: Franchise/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var franchise = await _context.Franchise
                .FirstOrDefaultAsync(m => m.Id == id);
            if (franchise == null)
            {
                return NotFound();
            }

            return View(franchise);
        }

        // POST: Franchise/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var franchise = await _context.Franchise.FindAsync(id);
            _context.Franchise.Remove(franchise);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FranchiseExists(int id)
        {
            return _context.Franchise.Any(e => e.Id == id);
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
