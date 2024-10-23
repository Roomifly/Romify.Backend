using MediatR;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.UserCases.Queries
{
    public class GetUserByIdQuery:IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
    }
}
