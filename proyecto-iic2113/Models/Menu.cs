using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_iic2113.Models
{
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string FoodName { get; set; }

        [Required]
        public bool IsVegan { get; set; }

        public int LaunchId { get; set; }
        public Launch Launch { get; set; }
    }
}
