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
        public ViewResult Index()
        {
            var numberOfEventsPerType = 3;

            var parties = _context.Parties
                .Include(party => party.Conference)
                .Take(numberOfEventsPerType);
            var workshops = _context.Parties
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

            ViewBag.parties = parties;
            ViewBag.workshops = workshops;
            ViewBag.launches = launches;
            ViewBag.chats = chats;
            ViewBag.talks = talks;

            return View();
        }
    }
}
