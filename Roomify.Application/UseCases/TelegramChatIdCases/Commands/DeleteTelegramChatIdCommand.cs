using MediatR;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.TelegramChatIdCases.Commands
{
    public class DeleteTelegramChatIdCommand:IRequest<ResponseModel>
    {
        public Guid UserId { get; set; }
        public long ChatId { get; set; }
    }
}
