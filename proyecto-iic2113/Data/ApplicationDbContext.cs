using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using proyecto_iic2113.Models;

namespace proyecto_iic2113.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        //Estas tablas son creables ssi las clases son alcanzables desde esta App

        public DbSet<Event> Events { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Sponsor> Sponsors{ get; set; }
        public DbSet<Conference> Conferences { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
