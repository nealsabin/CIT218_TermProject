using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TermProject.Models;

namespace TermProject.Models
{
    public class RideContext : DbContext
    {
        public RideContext (DbContextOptions<RideContext> options) : base(options)
        {

        }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Bike> Bikes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Difficulty>().HasData(
                new Difficulty { DifficultyId = "1", Rating = "Easy"},
                new Difficulty { DifficultyId = "2", Rating = "Medium" },
                new Difficulty { DifficultyId = "3", Rating = "Hard" }
                );

            modelBuilder.Entity<Bike>().HasData(
                new Bike { BikeId = 1, Make = "Specialized", Model = "Sequoia"},
                new Bike { BikeId = 2, Make = "Surly", Model = "Pugsly" },
                new Bike { BikeId = 3, Make = "Kona", Model = "Unit X" }
                );

            modelBuilder.Entity<Ride>().HasData(
                new Ride
                {
                    RideId = 1,
                    Name = "Around Superior",
                    Days = 16,
                    State = "MI",
                    Miles = 1200,
                    Description = "This bikepacking trip takes your around the largest lake by surface in the world.",
                    StartDate = new DateTime(2020,4,10),
                    DifficultyId = "3",
                    BikeId = 1
                },
                new Ride
                {
                    RideId = 2,
                    Name = "Leelanau Peninsula",
                    Days = 3,
                    State = "MI",
                    Miles = 180,
                    Description = "A trip around the scenic Leelanau Peninsula.",
                    StartDate = new DateTime(2020, 7, 11),
                    DifficultyId = "1",
                    BikeId = 1
                },
                new Ride
                {
                    RideId = 3,
                    Name = "Huron Mountains",
                    Days = 4,
                    State = "MI",
                    Miles = 210,
                    Description = "A rugged, remote trip awaits with this route around the Huron Mountains, in the Upper Peninsula of Michigan.",
                    StartDate = new DateTime(2018, 6, 20),
                    DifficultyId = "2",
                    BikeId = 2
                },
                new Ride
                {
                    RideId = 4,
                    Name = "Keweenaw Peninsula",
                    Days = 5,
                    State = "MI",
                    Miles = 220,
                    Description = "You will encounter some of the most beautiful coastline Michigan has to offer in this trip.",
                    StartDate = new DateTime(2019, 9, 1),
                    DifficultyId = "2",
                    BikeId = 3
                }
                );
        }

        public DbSet<TermProject.Models.Bike> Bike { get; set; }
    }
}
