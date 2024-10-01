using MediatR;
using Roomify.Application.UseCases.UserCases.Commands;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.UserCases.Handlers.CommandHandlers
{
    public class SendVerificationToUserCommandHandler : IRequestHandler<SendVerificationToUserCommand, ResponseModel>
    {
        public Task<ResponseModel> Handle(SendVerificationToUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
