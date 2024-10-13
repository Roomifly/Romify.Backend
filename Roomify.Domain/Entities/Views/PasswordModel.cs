namespace Roomify.Domain.Entities.Views
{
    public class PasswordModel
    {
        public string PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
