using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TermProject.Models
{
    public class RideContext : DbContext
    {
        public RideContext (DbContextOptions<RideContext> options) : base(options)
        {

        }
        public DbSet<Ride> Rides { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ride>().HasData(
                new Ride
                {
                    RideId = 1,
                    Name = "Around Superior",
                    Days = 16,
                    Miles = 1200,
                    Description = "This bikepacking trip takes your around the largest lake by surface in the world."
                },
                new Ride
                {
                    RideId = 2,
                    Name = "Leelanau Peninsula",
                    Days = 3,
                    Miles = 180,
                    Description = "A trip around the scenic Leelanau Peninsula."
                },
                new Ride
                {
                    RideId = 3,
                    Name = "Huron Mountains",
                    Days = 4,
                    Miles = 210,
                    Description = "A rugged, remote trip awaits with this route around the Huron Mountains, in the Upper Peninsula of Michigan."
                },
                new Ride
                {
                    RideId = 4,
                    Name = "Keweenaw Peninsula",
                    Days = 5,
                    Miles = 220,
                    Description = "You will encounter some of the most beautiful coastline Michigan has to offer in this trip."
                }
                );
        }
    }
}
