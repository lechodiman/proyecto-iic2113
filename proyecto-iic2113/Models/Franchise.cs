using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_iic2113.Models
{
    public class Franchise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name cannot be blank")]
        public string Name { get; set; }
        public string Description { get; set; }

        public ApplicationUser Organizer { get; set; }

        public IEnumerable<Conference> Conferences { get; set; }
    }
}
