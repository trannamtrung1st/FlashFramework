using FlashFramework.Email.Services;
using FlashFramework.Modules.EmailModule.Smtp.Email.Services;
using FlashFramework.Modules.EmailModule.Smtp.Email.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlashFramework.Modules.EmailModule.Smtp.Email.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSimpleEmailService(this IServiceCollection services, IConfiguration smtpConfigSection)
        {
            return services.Configure<SmtpOptions>(smtpConfigSection)
                .AddSingleton<ISimpleEmailService, SimpleEmailService>()
                .AddSingleton<IEmailService>(provider => provider.GetRequiredService<ISimpleEmailService>());
        }

        public static IServiceCollection AddSimpleEmailService(this IServiceCollection services, Action<SmtpOptions> config)
        {
            return services.Configure(config)
                .AddSingleton<ISimpleEmailService, SimpleEmailService>()
                .AddSingleton<IEmailService>(provider => provider.GetRequiredService<ISimpleEmailService>());
        }
    }
}
