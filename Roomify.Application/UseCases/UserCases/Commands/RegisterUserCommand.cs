using MediatR;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.UserCases.Commands
{
    public class RegisterUserCommand:IRequest<ResponseModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string SentPassword { get; set; }
    }
}
