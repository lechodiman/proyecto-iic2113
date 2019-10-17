using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace proyecto_iic2113.Models
{
    public class User : IdentityUser
    {
        public string CustomTag { get; set; }
        public IEnumerable<Conference> Conferences { get; set; }
    }
}


