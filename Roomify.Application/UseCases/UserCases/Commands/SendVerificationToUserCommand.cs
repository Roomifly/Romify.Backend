﻿using MediatR;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.UserCases.Commands
{
    public class SendVerificationToUserCommand:IRequest<ResponseModel>
    {
        public string Email { get; set; }
        public bool IsPasswordForgotten { get; set; }
    }
}
