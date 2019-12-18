using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_iic2113.Models
{
    public class ConferenceUserAttendee
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser UserAttendee { get; set; }

        public int ConferenceId { get; set; }
        public Conference Conference { get; set; }
    }
}
