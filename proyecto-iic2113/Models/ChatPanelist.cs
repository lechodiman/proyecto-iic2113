using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_iic2113.Models
{
    public class ChatPanelist
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser Panelist { get; set; }

        public int ChatId { get; set; }
        public Chat Chat { get; set; }
    }
}
