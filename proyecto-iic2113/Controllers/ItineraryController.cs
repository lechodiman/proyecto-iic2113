using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using proyecto_iic2113.Data;
using proyecto_iic2113.Models;

namespace proyecto_iic2113.Controllers
{
    public class ItineraryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        private readonly UserManager<ApplicationUser> _userManager;

        public ItineraryController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        // GET: Sponsor/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            ApplicationUser currentUser = await GetCurrentUserAsync();

            var conferences = await _context.ConferenceUserAttendees.Where(a => a.ApplicationUserId == currentUser.Id).ToListAsync();
            ViewBag.Conferences = conferences;

            var events = await _context.EventUserAttendees.Where(a => a.ApplicationUserId == currentUser.Id).ToListAsync();
            ViewBag.Events = events;



            return View();
        }
    }
}
