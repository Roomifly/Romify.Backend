namespace Roomify.Application.UseCases.UserCases.Commands
{
    public class RegisterUserCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string SentPassword { get; set; }
    }
}
