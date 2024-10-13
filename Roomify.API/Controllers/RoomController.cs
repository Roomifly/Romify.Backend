using MediatR;
using Microsoft.AspNetCore.Mvc;
using Roomify.Application.UseCases.RoomCases.Commands;
using Roomify.Application.UseCases.RoomCases.Queries;
using Roomify.Domain.Entities.Models.PrimaryModels;
using Roomify.Domain.Entities.Views;

namespace Roomify.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Room>> GetAll()
        {
            return await _mediator.Send(new GetAllRoomsQuery());
        }

        [HttpPost]
        public async Task<ResponseModel> Create(CreateRoomCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete]
        public async Task<ResponseModel> delete(DeleteRoomCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
