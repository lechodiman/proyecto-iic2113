using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using proyecto_iic2113.Models;

namespace proyecto_iic2113.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Talk> Talks { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Workshop> Workshops { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // The many to many relationsips need to be configured using the Fluent API below

            modelBuilder.Entity<ChatPanelist>()
                .HasKey(cp => new { cp.ChatId, cp.ApplicationUserId });

            // The model ChatPanelist has one Chat
            // And that Chat has many ChatPanelists
            // And the ChatPanelist uses the foreign key ChatId
            modelBuilder.Entity<ChatPanelist>()
                .HasOne(cp => cp.Chat)
                .WithMany(c => c.ChatPanelists)
                .HasForeignKey(cp => cp.ChatId);

            modelBuilder.Entity<ChatPanelist>()
                .HasOne(cp => cp.Panelist)
                .WithMany(user => user.ChatPanelists)
                .HasForeignKey(cp => cp.ApplicationUserId);

        }
    }
}
