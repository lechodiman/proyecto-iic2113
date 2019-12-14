using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;

namespace proyecto_iic2113.Models
{
    public class ApplicationUser : IdentityUser
    {
        public IEnumerable<Conference> Conferences { get; set; }

        public IEnumerable<ChatPanelist> ChatPanelists { get; set; }
        public IEnumerable<TalkLecturer> TalkLecturers { get; set; }
        public IEnumerable<WorkshopExhibitor> WorkshopExhibitors { get; set; }
        public IEnumerable<ConferenceUserAttendee> ConferenceUserAttendees { get; set; }

        public IEnumerable<Venue> Venues { get; set; }
        public IEnumerable<EventUserAttendee> EventUserAttendees { get; set; }
    }
}
