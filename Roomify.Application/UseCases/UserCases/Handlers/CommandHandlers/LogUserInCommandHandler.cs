using MediatR;
using Roomify.Application.UseCases.UserCases.Commands;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.UserCases.Handlers.CommandHandlers
{
    public class LogUserInCommandHandler : IRequestHandler<LogUserInCommand, ResponseModel>
    {
        public Task<ResponseModel> Handle(LogUserInCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
