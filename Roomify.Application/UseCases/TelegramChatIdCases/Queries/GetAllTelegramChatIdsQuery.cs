using MediatR;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.TelegramChatIdCases.Queries
{
    public class GetAllTelegramChatIdsQuery:IRequest<ResponseModel>
    {
    }
}
