using MediatR;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.UserCases.Queries
{
    public class GetAllUsersQuery:IRequest<IEnumerable<UserView>>
    {
    }
}
