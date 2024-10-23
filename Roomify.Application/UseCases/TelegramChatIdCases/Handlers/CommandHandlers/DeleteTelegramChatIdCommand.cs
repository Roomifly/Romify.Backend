using MediatR;
using Microsoft.EntityFrameworkCore;
using Roomify.Application.Abstraction;
using Roomify.Application.UseCases.TelegramChatIdCases.Commands;
using Roomify.Domain.Entities.Enums;
using Roomify.Domain.Entities.Models.PrimaryModels;
using Roomify.Domain.Entities.Models.SecondaryModels;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.TelegramChatIdCases.Handlers.CommandHandlers
{
    public class DeleteTelegramChatIdCommandHandler : IRequestHandler<DeleteTelegramChatIdCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteTelegramChatIdCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ResponseModel> Handle(DeleteTelegramChatIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User user = await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Id == request.UserId);

                if (user == null)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        StatusCode = 404,
                        Response = "User not found!"
                    };
                }

                if (user.Role != Roles.SuperAdmin)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        StatusCode = 400,
                        Response = "User is not SuperAdmin!"
                    };
                }

                TelegramChatId telegramChatId = await _applicationDbContext.TelegramChatIds.FirstOrDefaultAsync(t => t.ChatId == request.ChatId);

                if (telegramChatId == null)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        StatusCode = 404,
                        Response = "ChatId not found to delete!"
                    };
                }

                _applicationDbContext.TelegramChatIds.Remove(telegramChatId);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Response = "ChatId successfully deleted!"
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
