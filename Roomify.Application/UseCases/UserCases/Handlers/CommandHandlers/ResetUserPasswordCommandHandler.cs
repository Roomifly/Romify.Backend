using MediatR;
using Microsoft.EntityFrameworkCore;
using Roomify.Application.Abstraction;
using Roomify.Application.Services.AuthServices;
using Roomify.Application.Services.PasswordService;
using Roomify.Application.UseCases.UserCases.Commands;
using Roomify.Domain.Entities.Models.PrimaryModels;
using Roomify.Domain.Entities.Models.SecondaryModels;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.UserCases.Handlers.CommandHandlers
{
    public class ResetUserPasswordCommandHandler : IRequestHandler<ResetUserPasswordCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IAuthService _authService;
        private readonly IPasswordService _passwordService;

        public ResetUserPasswordCommandHandler(IApplicationDbContext applicationDbContext, IAuthService authService, IPasswordService passwordService)
        {
            _applicationDbContext = applicationDbContext;
            _authService = authService;
            _passwordService = passwordService;
        }

        public async Task<ResponseModel> Handle(ResetUserPasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User user = await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

                if (user == null)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        StatusCode = 404,
                        Response = "User not found to reset password!"
                    };
                }

                Verification verification = await _applicationDbContext.Verifications.FirstOrDefaultAsync(v => v.Email == request.Email && v.SentPassword == request.SentPassword);

                if (verification == null)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        StatusCode = 400,
                        Response = "Sent password is incorrect!"
                    };
                }

                PasswordModel passwordModel=_passwordService.HashPassword(request.NewPassword);

                user.PasswordHash = passwordModel.PasswordHash;
                user.PasswordSalt = passwordModel.PasswordSalt;

                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                string token = _authService.GenerateToken(user);

                return new ResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Response = token
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Response = $"Something went wrong: {ex.Message}"
                };
            }
        }
    }
}
