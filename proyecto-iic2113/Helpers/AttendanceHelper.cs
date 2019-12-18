using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using proyecto_iic2113.Data;
using proyecto_iic2113.Models;

namespace proyecto_iic2113.Helpers
{
    public class AttendanceHelper
    {
        private ApplicationDbContext _context;

        public AttendanceHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsUserAttendingEvent(ApplicationUser user, Event currentEvent)
        {
            var existingEventUserAttendee = await _context.EventUserAttendees
                .SingleOrDefaultAsync(m => m.EventId == currentEvent.Id && m.ApplicationUserId == user.Id);

            return existingEventUserAttendee != null;
        }

        public async Task<bool> IsUserAttendingConference(ApplicationUser user, Conference conference)
        {
            var conferenceUserAttendees = await _context
                .ConferenceUserAttendees
                .SingleOrDefaultAsync(cu => cu.ConferenceId == conference.Id && cu.ApplicationUserId == user.Id);

            return conferenceUserAttendees != null;
        }

    }
}
