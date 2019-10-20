using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_iic2113.Models
{
    public class Launch : Event
    {
        public bool IsAllYouCanEat { get; set; }
        public IEnumerable<Menu> Menus { get; set; }
    }
}
