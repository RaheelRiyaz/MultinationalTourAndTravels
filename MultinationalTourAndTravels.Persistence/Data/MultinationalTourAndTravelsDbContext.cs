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



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedData();
        }
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
        public DbSet<Contact> Contacts { get; set; } = null!;
        #endregion Tables




    }

    #region Seed Data

    public static class ModelBuilderExtentions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<User>().HasData(new User
            {
                Id = Guid.Parse("1b61edcd-aac5-4aeb-896a-6b197afe90d3"),
                Email = "multinationaltravellers@gmail.com",
                Password = "MnadJgpdArFr7ARvOV7jxReCAjCaR6vlGqo+LYcacKU=",
                Salt = "Obq2D6we1CB3GIFd5vhpC2ASw9FovYEsnWq13TQoC7s=",
                CreatedOn = DateTime.Now,
            });



            modelBuilder.Entity<LinkTree>().HasData(
                new LinkTree
                {
                    Address = String.Empty,
                    Facebbook = String.Empty,
                    Google = String.Empty,
                    Instagram = String.Empty,
                    Youtube = String.Empty,
                    Whatsapp = String.Empty,
                    Twitter = String.Empty,
                    CreatedOn = DateTime.Now,
                    Id = Guid.NewGuid(),
                    UpdatedOn = DateTime.Now
                }
                );
        }
    }
    #endregion Seed Data

}
