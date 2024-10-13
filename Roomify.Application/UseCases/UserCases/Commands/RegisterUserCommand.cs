using MediatR;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.UserCases.Commands
{
    public class RegisterUserCommand:IRequest<ResponseModel>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GroupName { get; set; }
        public string StudentId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SentPassword { get; set; }
    }
}
