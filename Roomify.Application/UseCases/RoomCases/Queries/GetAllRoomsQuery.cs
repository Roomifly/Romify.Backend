using MediatR;
using Roomify.Domain.Entities.Models.PrimaryModels;

namespace Roomify.Application.UseCases.RoomCases.Queries
{
    public class GetAllRoomsQuery:IRequest<IEnumerable<Room>>
    {
    }
}
