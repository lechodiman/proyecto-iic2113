using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_iic2113.Models
{
    public class Chat : Event
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser Moderator { get; set; }

        public IEnumerable<ChatPanelist> ChatPanelists { get; set; }
    }
}
