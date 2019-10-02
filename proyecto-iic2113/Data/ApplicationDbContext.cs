﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace proyecto_iic2113.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

    	public DbSet<Chat> Chats {get; set;}
    	public DbSet<Event> Events {get; set;}
    	public DbSet<Menu> Menus {get; set;}
    	public DbSet<Room> Rooms {get; set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
