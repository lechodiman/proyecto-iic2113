using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_iic2113.Models
{
    public class Workshop : Event
    {
        public IEnumerable<Resource> Resources { get; set; }

        public IEnumerable<WorkshopExhibitor> WorkshopExhibitors { get; set; }
    }
}
