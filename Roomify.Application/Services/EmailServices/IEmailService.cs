using Roomify.Domain.Entities.DTOs;
using Roomify.Domain.Entities.Views;

namespace Roomify.Application.Services.EmailServices
{
    public interface IEmailService
    {
        public Task<ResponseModel> SendEmailAsync(EmailDTO emailDTO);
    }
}
