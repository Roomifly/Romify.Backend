using Microsoft.EntityFrameworkCore;
using Roomify.Application.Abstraction;
using Roomify.Domain.Entities.Models.PrimaryModels;
using Roomify.Domain.Entities.Models.SecondaryModels;

namespace Roomify.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            Database.Migrate();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Verification> Verifications { get; set; }
    }
}
