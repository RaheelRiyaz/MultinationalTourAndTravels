using Microsoft.EntityFrameworkCore;
using MultinationalTourAndTravels.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Persistence.Data
{
    public class MultinationalTourAndTravelsDbContext : DbContext
    {
        public MultinationalTourAndTravelsDbContext(DbContextOptions options) : base(options) { }



<<<<<<< Updated upstream
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedData();
        }
=======


>>>>>>> Stashed changes
        #region Tables
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<AppFile> AppFiles { get; set; } = null!;
        public DbSet<Slider> Sliders { get; set; } = null!;
        public DbSet<Package> Packages { get; set; } = null!;
        public DbSet<Itinerary> Itineraries { get; set; } = null!;
        public DbSet<Inclusion> Inclusions { get; set; } = null!;
        public DbSet<Exlusion> Exlusions { get; set; } = null!;
        public DbSet<Hotel> Hotels { get; set; } = null!;
        public DbSet<PackageDestination> PackageDestinations { get; set; } = null!;
        public DbSet<DestinationDetails> DestinationDetails { get; set; } = null!;
        #endregion Tables
    }
}
