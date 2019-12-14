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

namespace proyecto_iic2113.Helpers
{
    public class AverageCalculator
    {
        private ApplicationDbContext _context;

        public AverageCalculator(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<double> CalculateUserTalkAverageAsync(string userId)
        {
            var filterTalks = await _context.TalkLecturers
                .Where(talkLecturer => talkLecturer.Lecturer.Id == userId)
                .Select(talkLecturer => talkLecturer.Talk)
                .ToListAsync();

            var talksAverageRatings = filterTalks
                .Select(async talk => await CalculateEventAverageAsync(talk.Id))
                .Select(task => task.Result)
                .ToList();
            var averageRating = talksAverageRatings.Count > 0 ? talksAverageRatings.Average() : 0.0;
            return averageRating;
        }

        public async Task<double> CalculateEventAverageAsync(int? eventId)
        {
            var reviews = await _context.Reviews
                .Where(r => r.EventId == eventId)
                .ToListAsync();

            var ratings = reviews.Select(x => x.Rating).ToList();
            var averageRating = ratings.Count > 0 ? ratings.Average() : 0.0;
            return averageRating;
        }

        public async Task<double> CalculateConferenceAverageAsync(int? conferenceId)
        {
            var events = await _context.Events
                .Where(e => e.ConferenceId == conferenceId)
                .ToListAsync();

            var eventsAverageRatings = events
                .Select(async e => await CalculateEventAverageAsync(e.Id))
                .Select(task => task.Result)
                .ToList();

            var averageRating = eventsAverageRatings.Count > 0 ? eventsAverageRatings.Average() : 0.0;
            return averageRating;
        }
    }
}
