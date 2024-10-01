using MediatR;
using Roomify.Application.UseCases.UserCases.Commands;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.UserCases.Handlers.CommandHandlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ResponseModel>
    {
        public Task<ResponseModel> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
