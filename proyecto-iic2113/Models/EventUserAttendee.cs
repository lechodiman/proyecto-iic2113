using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_iic2113.Models
{
    public class EventUserAttendee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser UserAttendee { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
