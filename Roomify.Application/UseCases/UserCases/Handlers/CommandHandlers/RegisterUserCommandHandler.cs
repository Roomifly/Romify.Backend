using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Roomify.Application.Abstraction;
using Roomify.Application.Services.AuthServices;
using Roomify.Application.Services.PasswordService;
using Roomify.Application.UseCases.UserCases.Commands;
using Roomify.Domain.Entities.Enums;
using Roomify.Domain.Entities.Models.PrimaryModels;
using Roomify.Domain.Entities.Models.SecondaryModels;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.UserCases.Handlers.CommandHandlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IPasswordService _passwordService;
        private readonly IAuthService _authService;

        public RegisterUserCommandHandler(IApplicationDbContext applicationDbContext, IPasswordService passwordService, IAuthService authService)
        {
            _applicationDbContext = applicationDbContext;
            _passwordService = passwordService;
            _authService = authService;
        }

        public async Task<ResponseModel> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Verification verification = await _applicationDbContext.Verifications.FirstOrDefaultAsync(v => v.Email == request.Email && v.SentPassword == request.SentPassword);

                if (verification == null)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        StatusCode = 400,
                        Response = "Sent password is incorrect"
                    };
                }

                User user = request.Adapt<User>();

                PasswordModel passwordModel = _passwordService.HashPassword(request.Password);

                user.PasswordHash = passwordModel.PasswordHash;
                user.PasswordSalt = passwordModel.PasswordSalt;
                user.Role = Roles.SimpleUser;

                _applicationDbContext.Verifications.Remove(verification);
                await _applicationDbContext.Users.AddAsync(user);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Response = _authService.GenerateToken(user)
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Response = $"Something went wrong!: {ex}"
                };
            }
        }
    }
}
