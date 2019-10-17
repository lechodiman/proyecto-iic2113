using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_iic2113.Models
{
    public class Chat : Event
    {
        // TODO: This should be a reference to a NxN table
        public IEnumerable<ApplicationUser> Panelists { get; set; }

        public int ApplicationUserId { get; set; }
        public ApplicationUser Moderator { get; set; }
    }
}
