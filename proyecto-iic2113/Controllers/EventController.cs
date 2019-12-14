using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using proyecto_iic2113.Data;
using proyecto_iic2113.Models;

namespace proyecto_iic2113.Controllers
{
    [AllowAnonymous]
    public class EventController : Controller
    {
        private ApplicationDbContext _context;
        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }
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

            var ratings = reviews.Select(x => x.Rating).ToList();
            var averageRating = ratings.Count > 0 ? ratings.Average() : 0.0;
            ViewBag.averageRating = averageRating;
            return View();
        }
    }
}
