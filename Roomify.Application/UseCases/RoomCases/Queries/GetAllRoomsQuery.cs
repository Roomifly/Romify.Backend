using MediatR;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.RoomCases.Queries
{
    public class GetAllRoomsQuery:IRequest<ResponseModel>
    {
    }
}
