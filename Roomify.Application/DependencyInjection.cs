using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Roomify.Application.Services.AuthServices;
using Roomify.Application.Services.EmailServices;
using Roomify.Application.Services.PasswordService;
using System.Reflection;

namespace Roomify.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPasswordService, PasswordService>();

            return services;
        }
    }
}
