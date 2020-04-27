using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeatherStationWebAPI.Models;

namespace WeatherStationWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        public DbSet<WeatherObservation> Observations { get; set; }
        public DbSet<Place> Places { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* Write Fluent API configurations here */

            //Place
            modelBuilder.Entity<Place>().HasKey(p => p.Name);

            // WeatherObservation
            modelBuilder.Entity<WeatherObservation>()
                .HasOne(w => w.Place)
                .WithOne()
                .HasForeignKey<WeatherObservation>();

        }
    }

}
