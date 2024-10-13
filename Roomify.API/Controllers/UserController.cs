using MediatR;
using Microsoft.AspNetCore.Mvc;
using Roomify.Application.UseCases.UserCases.Commands;
using Roomify.Domain.Entities.Views;

namespace Roomify.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ResponseModel> SendVerification(SendVerificationToUserCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<ResponseModel> Register(RegisterUserCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<ResponseModel> LogIn(LogUserInCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
