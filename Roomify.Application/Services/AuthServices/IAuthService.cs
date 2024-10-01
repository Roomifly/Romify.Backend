using Roomify.Domain.Entities.Models.PrimaryModels;

namespace Roomify.Application.Services.AuthServices
{
    public interface IAuthService
    {
        public string GenerateToken(User user);
    }
}
