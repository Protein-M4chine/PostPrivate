using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PostPrivate.Models;

namespace PostPrivate.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>()
                .HasKey(e => new { e.WithId, e.FromId });

            modelBuilder.Entity<Friend>()
                .HasOne(p => p.ProfileWith)
                .WithMany(f => f.FriendsFrom)
                .HasForeignKey(w => w.WithId);

            modelBuilder.Entity<Friend>()
                .HasOne(e => e.ProfileFrom)
                .WithMany(e => e.FriendsWith)
                .HasForeignKey(e => e.FromId);


            //modelBuilder.Entity<ApplicationUser>()
            //   .HasOne(p => p.Profile)
            //   .WithOne(u => u.User)
            //   .HasForeignKey<Profile>(u => u.ApplicationUserId)
            //   .OnDelete(DeleteBehavior.Cascade);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Profile>()
                .HasData(
                    new Profile()
                    {
                        Id = 1,
                        UserName = "protein_m4chine",
                        FName = "Sean",
                        LName = "Robinson",
                        Age = 27,
                        PhotoName = "sean.jpg",
                        DateJoined = DateTime.Now.ToString("MMMM yyyy"),
                        Bio = "Web Developer, Drummer, Citizen-Soldier, Drinker of Protein shakes"
                    },
                    new Profile()
                    {
                        Id = 2,
                        UserName = "deep_chaos",
                        FName = "Evan",
                        LName = "Robinson",
                        Age = 25,
                        PhotoName = "evan.jpg",
                        DateJoined = DateTime.Now.ToString("MMMM yyyy"),
                        Bio = "Effects Animationist, Bass Guitarist, Very much into Politics"
                    },
                    new Profile()
                    {
                        Id = 3,
                        UserName = "hav0c",
                        FName = "AJ",
                        LName = "Robinson",
                        Age = 22,
                        PhotoName = "aj.jpg",
                        DateJoined = DateTime.Now.ToString("MMMM yyyy"),
                        Bio = "Dronist, Guitarist, bored Alaskan"
                    },
                    new Profile()
                    {
                        Id = 4,
                        UserName = "bluegables",
                        FName = "Erica",
                        LName = "Robinson",
                        Age = 19,
                        PhotoName = "erica.jpg",
                        DateJoined = DateTime.Now.ToString("MMMM yyyy"),
                        Bio = "Student, Violinist, Student Driver"
                    }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
