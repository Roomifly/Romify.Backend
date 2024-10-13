using MediatR;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.RoomCases.Commands
{
    public class DeleteRoomCommand:IRequest<ResponseModel>
    {
        public Guid UserId { get; set; }
        public Guid RoomId { get; set; }
    }
}
