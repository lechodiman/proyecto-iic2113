using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_iic2113.Models
{
    public class WorkshopExhibitor
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser Exhibitor { get; set; }

        public int WorkshopId { get; set; }
        public Workshop Workshop { get; set; }
    }
}
