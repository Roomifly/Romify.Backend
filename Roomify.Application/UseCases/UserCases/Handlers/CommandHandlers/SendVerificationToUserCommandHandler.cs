using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Roomify.Application.Abstraction;
using Roomify.Application.Services.EmailServices;
using Roomify.Application.UseCases.UserCases.Commands;
using Roomify.Domain.Entities.DTOs;
using Roomify.Domain.Entities.Models.PrimaryModels;
using Roomify.Domain.Entities.Models.SecondaryModels;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.UserCases.Handlers.CommandHandlers
{
    public class SendVerificationToUserCommandHandler : IRequestHandler<SendVerificationToUserCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public SendVerificationToUserCommandHandler(IApplicationDbContext applicationDbContext, IEmailService sendEmailService, IConfiguration configuration)
        {
            _applicationDbContext = applicationDbContext;
            _emailService = sendEmailService;
            _configuration = configuration;
        }

        public async Task<ResponseModel> Handle(SendVerificationToUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User user = await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

                if (request.IsPasswordForgotten == null && user != null || request.IsPasswordForgotten == false && user != null)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        StatusCode = 400,
                        Response = "Email is already taken!"
                    };
                }
                else if (request.IsPasswordForgotten == true && user == null)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        StatusCode = 404,
                        Response = "Email not resgistered yet!!"
                    };
                }


                Verification verification = await _applicationDbContext.Verifications.FirstOrDefaultAsync(v => v.Email == request.Email);

                if (verification != null)
                {
                    _applicationDbContext.Verifications.Remove(verification);
                }

                Random random = new Random();

                string password = random.Next(100000, 999999).ToString();

                ResponseModel response = await _emailService.SendEmailAsync(new EmailDTO
                {
                    To = request.Email,
                    Subject = "Email verification!",
                    Body = password,
                    IsBodyHTML = true
                });

                if (response.IsSuccess)
                {
                    await _applicationDbContext.Verifications.AddAsync(new Verification
                    {
                        Email = request.Email,
                        SentPassword = password
                    });

                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                }

                return response;
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Response = "Something went wrong!"
                };
            }
        }
    }
}
