using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_iic2113.Models
{
    public class TalkLecturer
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser Lecturer { get; set; }

        public int TalkId { get; set; }
        public Talk Talk { get; set; }
    }
}
