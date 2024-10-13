using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Roomify.Application.Abstraction;
using Roomify.Application.UseCases.UserCases.Queries;
using Roomify.Domain.Entities.Models.PrimaryModels;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.UseCases.UserCases.Handlers.QueryHandlers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserView>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetAllUsersQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<UserView>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<User> users= await _applicationDbContext.Users.ToListAsync();
                List<UserView> userViews = new List<UserView>();

                foreach (User user in users)
                {
                    userViews.Add(user.Adapt<UserView>());
                }

                return userViews;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
