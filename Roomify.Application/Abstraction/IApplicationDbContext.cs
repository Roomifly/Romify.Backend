using Microsoft.EntityFrameworkCore;
using Roomify.Domain.Entities.Models.PrimaryModels;
using Roomify.Domain.Entities.Models.SecondaryModels;

namespace Roomify.Application.Abstraction
{
    public interface IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Verification> Verifications { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
