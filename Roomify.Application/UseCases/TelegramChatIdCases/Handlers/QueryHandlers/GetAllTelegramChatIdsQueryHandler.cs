using MediatR;
using Microsoft.EntityFrameworkCore;
using Roomify.Application.Abstraction;
using Roomify.Application.UseCases.TelegramChatIdCases.Queries;
using Roomify.Domain.Entities.Models.SecondaryModels;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.TelegramChatIdCases.Handlers.QueryHandlers
{
    public class GetAllTelegramChatIdsQueryHandler : IRequestHandler<GetAllTelegramChatIdsQuery, ResponseModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetAllTelegramChatIdsQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ResponseModel> Handle(GetAllTelegramChatIdsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<TelegramChatId> telegramChatIds = await _applicationDbContext.TelegramChatIds.ToListAsync();

                return new ResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Response = telegramChatIds
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
