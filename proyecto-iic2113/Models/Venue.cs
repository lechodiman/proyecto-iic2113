using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_iic2113.Models
{
    public class Venue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name cannot be blank")]
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Photo { get; set; }
        public IEnumerable<Conference> Conferences { get; set; }
        public IEnumerable<Room> Rooms { get; set; }

    }
}
