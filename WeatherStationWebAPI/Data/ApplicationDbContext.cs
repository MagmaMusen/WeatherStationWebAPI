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
            modelBuilder.Entity<Place>().HasKey(p => p.Id);
            modelBuilder.Entity<Place>().HasIndex(i => new{i.Latitude, i.Longitude}).IsUnique();

            // WeatherObservation
            modelBuilder.Entity<WeatherObservation>().HasKey(p => p.Id);
            modelBuilder.Entity<WeatherObservation>()
                .HasOne<Place>()
                .WithMany()
                .HasForeignKey(f => f.PlaceId);

        }
    }

}
