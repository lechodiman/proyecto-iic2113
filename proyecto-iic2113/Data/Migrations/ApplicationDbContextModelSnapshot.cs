﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using proyecto_iic2113.Data;

namespace proyecto_iic2113.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("proyecto_iic2113.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("proyecto_iic2113.Models.ChatPanelist", b =>
                {
                    b.Property<int>("ChatId");

                    b.Property<string>("ApplicationUserId");

                    b.HasKey("ChatId", "ApplicationUserId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("ChatPanelist");
                });

            modelBuilder.Entity("proyecto_iic2113.Models.Conference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("OrganizerId");

                    b.Property<int?>("VenueId");

                    b.HasKey("Id");

                    b.HasIndex("OrganizerId");

                    b.HasIndex("VenueId");

                    b.ToTable("Conferences");
                });

            modelBuilder.Entity("proyecto_iic2113.Models.ConferenceUserAssistee", b =>
                {
                    b.Property<int>("ConferenceId");

                    b.Property<string>("ApplicationUserId");

                    b.HasKey("ConferenceId", "ApplicationUserId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("ConferenceUserAssistee");
                });

            modelBuilder.Entity("proyecto_iic2113.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("RoomId");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("proyecto_iic2113.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ConferenceId");

                    b.Property<string>("Description");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("ConferenceId");

                    b.ToTable("Events");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Event");
                });

            modelBuilder.Entity("proyecto_iic2113.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FoodName")
                        .IsRequired();

                    b.Property<bool>("IsVegan");

                    b.Property<int>("LaunchId");

                    b.HasKey("Id");

                    b.HasIndex("LaunchId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("proyecto_iic2113.Models.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ResourceUrl");

                    b.Property<int>("WorkshopId");

                    b.HasKey("Id");

                    b.HasIndex("WorkshopId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("proyecto_iic2113.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Capacity");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Photo");

                    b.Property<int>("VenueId");

                    b.HasKey("Id");

                    b.HasIndex("VenueId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("proyecto_iic2113.Models.Sponsor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ConferenceId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ConferenceId");

                    b.ToTable("Sponsors");
                });

            modelBuilder.Entity("proyecto_iic2113.Models.TalkLecturer", b =>
                {
                    b.Property<int>("TalkId");

                    b.Property<string>("ApplicationUserId");

                    b.HasKey("TalkId", "ApplicationUserId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("TalkLecturer");
                });

            modelBuilder.Entity("proyecto_iic2113.Models.Venue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adress");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Photo");

                    b.HasKey("Id");

                    b.ToTable("Venues");
                });

            modelBuilder.Entity("proyecto_iic2113.Models.WorkshopExhibitor", b =>
                {
                    b.Property<int>("WorkshopId");

                    b.Property<string>("ApplicationUserId");

                    b.HasKey("WorkshopId", "ApplicationUserId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("WorkshopExhibitor");
                });

            modelBuilder.Entity("proyecto_iic2113.Models.Chat", b =>
                {
                    b.HasBaseType("proyecto_iic2113.Models.Event");

                    b.Property<string>("ApplicationUserId");

                    b.HasIndex("ApplicationUserId");

                    b.HasDiscriminator().HasValue("Chat");
                });

            modelBuilder.Entity("proyecto_iic2113.Models.Launch", b =>
                {
                    b.HasBaseType("proyecto_iic2113.Models.Event");

                    b.Property<bool>("IsAllYouCanEat");

                    b.HasDiscriminator().HasValue("Launch");
                });

            modelBuilder.Entity("proyecto_iic2113.Models.Party", b =>
                {
                    b.HasBaseType("proyecto_iic2113.Models.Event");

                    b.Property<bool>("HasOpenBar");

                    b.HasDiscriminator().HasValue("Party");
                });

            modelBuilder.Entity("proyecto_iic2113.Models.Talk", b =>
                {
                    b.HasBaseType("proyecto_iic2113.Models.Event");

                    b.Property<string>("Subject");

                    b.HasDiscriminator().HasValue("Talk");
                });

            modelBuilder.Entity("proyecto_iic2113.Models.Workshop", b =>
                {
                    b.HasBaseType("proyecto_iic2113.Models.Event");

                    b.HasDiscriminator().HasValue("Workshop");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("proyecto_iic2113.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("proyecto_iic2113.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("proyecto_iic2113.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("proyecto_iic2113.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("proyecto_iic2113.Models.ChatPanelist", b =>
                {
                    b.HasOne("proyecto_iic2113.Models.ApplicationUser", "Panelist")
                        .WithMany("ChatPanelists")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("proyecto_iic2113.Models.Chat", "Chat")
                        .WithMany("ChatPanelists")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("proyecto_iic2113.Models.Conference", b =>
                {
                    b.HasOne("proyecto_iic2113.Models.ApplicationUser", "Organizer")
                        .WithMany("Conferences")
                        .HasForeignKey("OrganizerId");

                    b.HasOne("proyecto_iic2113.Models.Venue", "Venue")
                        .WithMany("Conferences")
                        .HasForeignKey("VenueId");
                });

            modelBuilder.Entity("proyecto_iic2113.Models.ConferenceUserAssistee", b =>
                {
                    b.HasOne("proyecto_iic2113.Models.ApplicationUser", "UserAssistee")
                        .WithMany("ConferenceUserAssistees")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("proyecto_iic2113.Models.Conference", "Conference")
                        .WithMany("ConferenceUserAssistees")
                        .HasForeignKey("ConferenceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("proyecto_iic2113.Models.Equipment", b =>
                {
                    b.HasOne("proyecto_iic2113.Models.Room", "Room")
                        .WithMany("Equipments")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("proyecto_iic2113.Models.Event", b =>
                {
                    b.HasOne("proyecto_iic2113.Models.Conference", "Conference")
                        .WithMany()
                        .HasForeignKey("ConferenceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("proyecto_iic2113.Models.Menu", b =>
                {
                    b.HasOne("proyecto_iic2113.Models.Launch", "Launch")
                        .WithMany("Menus")
                        .HasForeignKey("LaunchId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("proyecto_iic2113.Models.Resource", b =>
                {
                    b.HasOne("proyecto_iic2113.Models.Workshop", "Workshop")
                        .WithMany("Resources")
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("proyecto_iic2113.Models.Room", b =>
                {
                    b.HasOne("proyecto_iic2113.Models.Venue", "Venue")
                        .WithMany("Rooms")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("proyecto_iic2113.Models.Sponsor", b =>
                {
                    b.HasOne("proyecto_iic2113.Models.Conference", "Conference")
                        .WithMany("Sponsors")
                        .HasForeignKey("ConferenceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("proyecto_iic2113.Models.TalkLecturer", b =>
                {
                    b.HasOne("proyecto_iic2113.Models.ApplicationUser", "Lecturer")
                        .WithMany("TalkLecturers")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("proyecto_iic2113.Models.Talk", "Talk")
                        .WithMany("TalkLecturers")
                        .HasForeignKey("TalkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("proyecto_iic2113.Models.WorkshopExhibitor", b =>
                {
                    b.HasOne("proyecto_iic2113.Models.ApplicationUser", "Exhibitor")
                        .WithMany("WorkshopExhibitors")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("proyecto_iic2113.Models.Workshop", "Workshop")
                        .WithMany("WorkshopExhibitors")
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("proyecto_iic2113.Models.Chat", b =>
                {
                    b.HasOne("proyecto_iic2113.Models.ApplicationUser", "Moderator")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
