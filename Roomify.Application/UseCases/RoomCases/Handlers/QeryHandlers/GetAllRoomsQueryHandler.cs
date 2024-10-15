using MediatR;
using Microsoft.EntityFrameworkCore;
using Roomify.Application.Abstraction;
using Roomify.Application.UseCases.RoomCases.Queries;
using Roomify.Domain.Entities.Models.PrimaryModels;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.RoomCases.Handlers.QeryHandlers
{
    public class GetAllRoomsQueryHandler : IRequestHandler<GetAllRoomsQuery, ResponseModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetAllRoomsQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ResponseModel> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<Room> rooms = await _applicationDbContext.Rooms.ToListAsync();

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