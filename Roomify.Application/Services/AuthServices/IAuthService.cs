using Roomify.Domain.Entities.Models;

namespace Roomify.Application.Services.AuthServices
{
    public interface IAuthService
    {
        public string GenerateToken(User user);
    }
}
