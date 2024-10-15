using MediatR;
using Microsoft.AspNetCore.Mvc;
using Roomify.Application.UseCases.ReservetionCases.Commands;
using Roomify.Domain.Entities.Views;

namespace Roomify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ResponseModel> Reserve(ReserveRoomCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
