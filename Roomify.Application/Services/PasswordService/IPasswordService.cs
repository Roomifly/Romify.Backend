using Roomify.Domain.Entities.Views;

namespace Roomify.Application.Services.PasswordService
{
    public interface IPasswordService
    {
        public bool CheckPassword(string password, PasswordModel passwordModel);

        public PasswordModel HashPassword(string password);
    }
}
