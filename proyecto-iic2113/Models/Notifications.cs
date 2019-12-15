using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace proyecto_iic2113.Models
{
    public class Notifications
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(1000)]
        public string Body { get; set; }

        public ApplicationUser Receiver { get; set; }
        public string ApplicationUserId { get; set; }

        public Conference Conference { get; set; }
        public int ConferenceId { get; set; }

        public Event Event { get; set; }
        public int? EventId { get; set; }

    }
}
