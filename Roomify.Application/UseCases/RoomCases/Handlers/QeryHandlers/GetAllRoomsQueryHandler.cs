using MediatR;
using Microsoft.EntityFrameworkCore;
using Roomify.Application.Abstraction;
using Roomify.Application.UseCases.RoomCases.Queries;
using Roomify.Domain.Entities.Models.PrimaryModels;

namespace Roomify.Application.UseCases.RoomCases.Handlers.QeryHandlers
{
    public class GetAllRoomsQueryHandler : IRequestHandler<GetAllRoomsQuery, IEnumerable<Room>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetAllRoomsQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<Room>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _applicationDbContext.Rooms.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}

/*
        private readonly IApplicationDbContext _applicationDbContext;

        public GetAllRoomsQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
*/