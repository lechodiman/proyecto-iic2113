using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_iic2113.Models
{
    public class Conference
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name cannot be blank")]
        public string Name { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }
        public IEnumerable<Sponsor> Sponsors { get; set; }
        public ApplicationUser Organizer { get; set; }
        public int? VenueId { get; set; }
        public Venue Venue { get; set; }
        public IEnumerable<ConferenceUserAttendee> ConferenceUserAttendees { get; set; }

        public IEnumerable<Launch> Launches { get; set; }
        public IEnumerable<Workshop> Workshops { get; set; }
        public IEnumerable<Talk> Talks { get; set; }
        public IEnumerable<Party> Parties { get; set; }
        public IEnumerable<Chat> Chats { get; set; }
    }
}
