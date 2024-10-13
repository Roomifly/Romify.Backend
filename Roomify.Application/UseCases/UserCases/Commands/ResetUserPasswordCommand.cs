using MediatR;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.UserCases.Commands
{
    public class ResetUserPasswordCommand:IRequest<ResponseModel>
    {
        public string Email { get; set; }
        public string SentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
