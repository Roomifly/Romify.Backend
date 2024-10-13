using Microsoft.EntityFrameworkCore;
using Roomify.Application.Abstraction;
using Roomify.Domain.Entities.Enums;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id=Guid.NewGuid(),
                    FirstName="Adminaka",
                    LastName="Abdukholiqov",
                    GroupName="DotNet N11",
                    StudentId="12345",
                    PhoneNumber="9000010001",
                    Email="abdukholiq0907@gmail.com",
                    PasswordHash= "8754CF62B0513606377E4EB9814F08466863E3F66FCA3BAC2A2F084FB2C4A40A4F28C107DE7B6EE35A6E874FECBCE128B98E79F0CB9A5E80E46A221539ED063B",
                    PasswordSalt = [243, 146, 109, 197, 58, 188, 62, 82, 98, 245, 103, 155, 170, 196, 36, 74, 243, 239, 53, 137, 30, 113, 81, 97, 144, 228, 238, 217, 135, 69, 8, 197, 119, 241, 74, 202, 193, 9, 97, 178, 212, 136, 18, 38, 203, 91, 209, 8, 179, 168, 139, 98, 227, 37, 230, 118, 101, 67, 227, 37, 121, 202, 179, 177],
                    Role=Roles.SuperAdmin
                    // Password = "admin0907"
                }
            );
        }
    }
}
