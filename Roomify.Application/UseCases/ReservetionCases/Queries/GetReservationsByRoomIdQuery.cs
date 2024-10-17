using MediatR;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.ReservetionCases.Queries
{
    public class GetReservationsByRoomIdQuery:IRequest<ResponseModel>
    {
        public Guid RoomId { get; set; }
    }
}
