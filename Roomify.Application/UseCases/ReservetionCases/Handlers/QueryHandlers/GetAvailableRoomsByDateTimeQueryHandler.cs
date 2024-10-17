using MediatR;
using Microsoft.EntityFrameworkCore;
using Roomify.Application.Abstraction;
using Roomify.Application.UseCases.ReservetionCases.Queries;
using Roomify.Domain.Entities.Models.PrimaryModels;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.ReservetionCases.Handlers.QueryHandlers
{
    public class GetAvailableRoomsByDateTimeQueryHandler : IRequestHandler<GetAvailableRoomsByDateTimeQuery, ResponseModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetAvailableRoomsByDateTimeQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ResponseModel> Handle(GetAvailableRoomsByDateTimeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                TimeOnly.TryParse(request.StartTime, out TimeOnly startTime);
                TimeOnly.TryParse(request.FinishTime, out TimeOnly finishTime);
                DateOnly date = DateOnly.FromDateTime(DateTime.Today);

                if (startTime > finishTime || date.DayOfWeek > request.Day)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        StatusCode = 400,
                        Response = "Period of reservation is incorrect!"
                    };
                }

                IEnumerable<Reservation> reservations = await _applicationDbContext.Reservations.Where(r => r.StartTime < finishTime && r.FinishTime > startTime && r.Day == request.Day ? r.Date == date : false).ToListAsync();
                List<Room> rooms = await _applicationDbContext.Rooms.ToListAsync();

                List<Guid> busyRoomIds= reservations.Select(r => r.RoomId).ToList();

                rooms = rooms.Where(room => !busyRoomIds.Contains(room.Id)).ToList();

                return new ResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Response = rooms
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
