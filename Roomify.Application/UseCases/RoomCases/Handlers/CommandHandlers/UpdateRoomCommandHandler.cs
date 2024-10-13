using MediatR;
using Roomify.Application.Abstraction;
using Roomify.Application.UseCases.RoomCases.Commands;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.RoomCases.Handlers.CommandHandlers
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateRoomCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ResponseModel> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            try
            {

            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Response = $"Something went wrong: {ex.Message}"
                };
            }
        }
    }
}
