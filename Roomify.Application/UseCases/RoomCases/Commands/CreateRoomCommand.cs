using MediatR;
using Microsoft.AspNetCore.Http;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.RoomCases.Commands
{
    public class CreateRoomCommand:IRequest<ResponseModel>
    {
        public Guid UserId { get; set; }
        public string Number { get; set; }
        public byte Floor { get; set; }
        public IFormFile Image { get; set; }
    }
}
