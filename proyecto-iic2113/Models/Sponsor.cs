using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_iic2113.Models
{
    public class Sponsor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public Conference Conference { get; set; }
        public int ConferenceId { get; set; }
    }
}
