using MediatR;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.RoomCases.Commands
{
    public class CreateRoomCommand:IRequest<ResponseModel>
    {
        public Guid UserId { get; set; }
        public string RoomNumber { get; set; }
        public byte Floor { get; set; }
    }
}
