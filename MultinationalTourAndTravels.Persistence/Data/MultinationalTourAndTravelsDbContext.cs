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
        public DbSet<ChatQuestion> ChatQuestions { get; set; } = null!;
        public DbSet<ChatAnswer> ChatAnswers { get; set; } = null!;
        public DbSet<PackageCosting> PackageCostings { get; set; } = null!;
        public DbSet<Cab> Cabs { get; set; } = null!;
        public DbSet<LinkTree> LinkTrees { get; set; } = null!;
        public DbSet<Booking> Bookings { get; set; } = null!;
        #endregion Tables
    }
}
