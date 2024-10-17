using MediatR;
using Microsoft.AspNetCore.Mvc;
using Roomify.Application.UseCases.ReservetionCases.Commands;
using Roomify.Application.UseCases.ReservetionCases.Queries;
using Roomify.Domain.Entities.Views;

namespace Roomify.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{day}/{startTime}/{finishTime}")]
        public async Task<ResponseModel> GetAvailableRooms(DayOfWeek day,string startTime,string finishTime)
        {
            return await _mediator.Send(new GetAvailableRoomsByDateTimeQuery
            {
                Day = day,
                StartTime = startTime,
                FinishTime = finishTime
            });
        }

        [HttpGet]
        [Route("{roomId}")]
        public async Task<ResponseModel> GetReservationsByRoomId(Guid roomId)
        {
            return await _mediator.Send(new GetReservationsByRoomIdQuery { RoomId = roomId });
        }

        [HttpPost]
        public async Task<ResponseModel> Reserve(ReserveRoomCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ResponseModel> CancelReservation(Guid id)
        {
            return await _mediator.Send(new CancelReservationCommand { Id = id });
        }
    }
}
