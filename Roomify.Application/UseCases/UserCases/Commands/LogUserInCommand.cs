using MediatR;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.UserCases.Commands
{
    public class LogUserInCommand:IRequest<ResponseModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
