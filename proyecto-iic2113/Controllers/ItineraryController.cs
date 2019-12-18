using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using proyecto_iic2113.Data;
using proyecto_iic2113.Models;
using System;

namespace proyecto_iic2113.Controllers
{
    public class ItineraryController : Controller
    {
        private readonly ApplicationDbContext _context;
       
        private readonly UserManager<ApplicationUser> _userManager;

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

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
        
            var baseConferenceQuery = await _context.ConferenceUserAttendees
                .Join(
                    _context.Conferences,
                    attendance => attendance.ConferenceId,
                    conference => conference.Id,
                    (attendance, conference) => new AttendanceView
                    {
                        ConferenceId = conference.Id,
                        Name = conference.Name,
                        Venue = conference.Venue.Name,
                        EndDate = conference.EndDate,
                        DateTime = conference.DateTime,
                        ApplicationUserId = attendance.ApplicationUserId
                        
                    }
                ).Where(a => a.ApplicationUserId == currentUser.Id).ToListAsync();

            ViewBag.Conferences = baseConferenceQuery;


            ViewBag.Parties = await _context.EventUserAttendees
                .Join(
                    _context.Parties,
                    attendance => attendance.EventId,
                    event_i => event_i.Id,
                    (attendance, event_i) => new AttendanceViewEvent
                    {
                        EventId = event_i.Id,
                        Name = event_i.Name,
                        EndDate = event_i.EndDate,
                        StartDate = event_i.StartDate,
                        ApplicationUserId = attendance.ApplicationUserId


                    }
                ).Where(e => e.ApplicationUserId == currentUser.Id).ToListAsync();


            ViewBag.Lunches = await _context.EventUserAttendees
                .Join(
                    _context.Launches,
                    attendance => attendance.EventId,
                    event_i => event_i.Id,
                    (attendance, event_i) => new AttendanceViewEvent
                    {
                        EventId = event_i.Id,
                        Name = event_i.Name,
                        EndDate = event_i.EndDate,
                        StartDate = event_i.StartDate,
                        ApplicationUserId = attendance.ApplicationUserId


                    }
                ).Where(e => e.ApplicationUserId == currentUser.Id).ToListAsync();


            ViewBag.Chats = await _context.EventUserAttendees
                .Join(
                    _context.Chat,
                    attendance => attendance.EventId,
                    event_i => event_i.Id,
                    (attendance, event_i) => new AttendanceViewEvent
                    {
                        EventId = event_i.Id,
                        Name = event_i.Name,
                        EndDate = event_i.EndDate,
                        StartDate = event_i.StartDate,
                        ApplicationUserId = attendance.ApplicationUserId


                    }
                ).Where(e => e.ApplicationUserId == currentUser.Id).ToListAsync();

            ViewBag.Talks = await _context.EventUserAttendees
                .Join(
                    _context.Talks,
                    attendance => attendance.EventId,
                    event_i => event_i.Id,
                    (attendance, event_i) => new AttendanceViewEvent
                    {
                        EventId = event_i.Id,
                        Name = event_i.Name,
                        EndDate = event_i.EndDate,
                        StartDate = event_i.StartDate,
                        ApplicationUserId = attendance.ApplicationUserId


                    }
                ).Where(e => e.ApplicationUserId == currentUser.Id).ToListAsync();

            return View();
        }
    }
}
