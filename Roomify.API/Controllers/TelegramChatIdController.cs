using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roomify.Application.UseCases.TelegramChatIdCases.Commands;
using Roomify.Application.UseCases.TelegramChatIdCases.Queries;
using Roomify.Domain.Entities.Views;

namespace Roomify.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TelegramChatIdController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TelegramChatIdController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ResponseModel> GetAll()
        {
            return await _mediator.Send(new GetAllTelegramChatIdsQuery());
        }

        [HttpPost]
        public async Task<ResponseModel> Create(CreateTelegramChatIdCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete]
        public async Task<ResponseModel> Delete(DeleteTelegramChatIdCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
