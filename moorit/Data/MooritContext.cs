using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Moorit.Models;

namespace Moorit.Data
{
    public class MooritContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Mooring> Moorings { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }
        public MooritContext(DbContextOptions<MooritContext> options)
            : base(options)
        {

        }
    }
}
