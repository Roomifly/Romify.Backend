using MediatR;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.UserCases.Commands
{
    public class DeleteUserCommand:IRequest<ResponseModel>
    {
        public Guid UserId { get; set; }
    }
}
