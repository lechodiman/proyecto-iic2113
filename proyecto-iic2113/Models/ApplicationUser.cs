using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;

namespace proyecto_iic2113.Models
{
    public class ApplicationUser : IdentityUser
    {
        public IEnumerable<Conference> Conferences { get; set; }

        public IEnumerable<ChatPanelist> ChatPanelists { get; set; }
    }
}
