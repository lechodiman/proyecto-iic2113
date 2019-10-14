using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_iic2113.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Photo { get; set; }
        public int VenueId { get; set; }
        public Venue Venue { get; set; }
        public IEnumerable<Equipment> Equipments { get; set; }
    }
}
