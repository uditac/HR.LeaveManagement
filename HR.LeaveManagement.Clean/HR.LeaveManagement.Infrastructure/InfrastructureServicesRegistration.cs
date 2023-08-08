using HR.Leavemanagement.Application.Contracts.Email;
using HR.Leavemanagement.Application.Contracts.Logging;
using HR.Leavemanagement.Application.Models.Email;
using HR.LeaveManagement.Infrastructure.EmailService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<EmailSetings>(configuration.GetSection("EmailSettings"));
        services.AddTransient<IEmailSender, EmailSender>(); // using a new instance of email sender each time it is used.
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<T>));
        return services;
    }
}