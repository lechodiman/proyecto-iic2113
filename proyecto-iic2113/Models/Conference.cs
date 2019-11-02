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
        [Required]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }
        public IEnumerable<Sponsor> Sponsors { get; set; }
        public ApplicationUser Organizer { get; set; }
        [Required(ErrorMessage = "A location is needed")]
        public int? VenueId { get; set; }
        public Venue Venue { get; set; }

    }
}
