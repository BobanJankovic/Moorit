using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Moorit.Infrastructure;
using Moorit.Models;

namespace Moorit.Data
{
    public class MooritContext : IdentityDbContext<ApplicationUserModel>
    {
        public DbSet<Mooring> Moorings { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Location> Locations { get; set; }


        public MooritContext(DbContextOptions<MooritContext> options)
            : base(options)
        {
           

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // Add custom model configuration logic here

        //    // Call the Seed method from the DataSeedClass after the model has been built
        //    new DataSeedClass(modelBuilder).Seed();
        //}


    }
}
