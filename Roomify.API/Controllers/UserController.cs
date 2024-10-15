using MediatR;
using Microsoft.AspNetCore.Mvc;
using Roomify.Application.UseCases.UserCases.Commands;
using Roomify.Application.UseCases.UserCases.Queries;
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

        [HttpGet]
        public async Task<ResponseModel> GetAll()
        {
            return await _mediator.Send(new GetAllUsersQuery());
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

        [HttpPost]
        public async Task<ResponseModel> ResetPassword(ResetUserPasswordCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete]
        public async Task<ResponseModel> Delete(DeleteUserCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
