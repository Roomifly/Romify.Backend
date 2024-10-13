using Roomify.Domain.Entities.Enums;

namespace Roomify.Domain.Entities.Models.PrimaryModels
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GroupName { get; set; }
        public string StudentId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Roles Role { get; set; }
    }
}
