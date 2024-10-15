using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Roomify.Application.Abstraction;
using Roomify.Application.UseCases.ReservetionCases.Commands;
using Roomify.Domain.Entities.Models.PrimaryModels;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.ReservetionCases.Handlers.CommandHandlers
{
    public class ReserveRoomCommandHandler : IRequestHandler<ReserveRoomCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public ReserveRoomCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ResponseModel> Handle(ReserveRoomCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User user = await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Id == request.UserId);

                if (user == null)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        StatusCode = 404,
                        Response = "User not found!"
                    };
                }

                Room room = await _applicationDbContext.Rooms.FirstOrDefaultAsync(r => r.Id == request.RoomId);

                if (room == null)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        StatusCode = 404,
                        Response = "Room not found to reserve!"
                    };
                }

                Reservation reservation = await _applicationDbContext.Reservations.FirstOrDefaultAsync(r=>r.Room==room&&r.StartTime)



                return new ResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Response = reservation
                };
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
