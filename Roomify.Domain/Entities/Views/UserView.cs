using Roomify.Domain.Entities.Enums;

namespace Roomify.Domain.Entities.Views
{
    public class UserView
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string GroupName { get; set; }
        public string StudentId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
