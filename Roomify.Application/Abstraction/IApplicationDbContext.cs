using Microsoft.EntityFrameworkCore;
using Roomify.Domain.Entities.Models;

namespace Roomify.Application.Abstraction
{
    public interface IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
