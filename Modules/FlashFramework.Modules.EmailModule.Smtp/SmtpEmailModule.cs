using FlashFramework.Common.Models;
using FlashFramework.Modules.EmailModule.Smtp.Email.Extensions;
using FlashFramework.Modules.EmailModule.Smtp.Pages.Sample;
using FlashFramework.Shared.Modular;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlashFramework.Modules.EmailModule.Smtp
{
    public class SmtpEmailModule : IModule
    {
        public string Name => "Smtp Email Module";

        public IEnumerable<IPage> Pages => new IPage[]
        {
            new EmailSettingsPage()
        };

        public IEnumerable<IComponent<IndexComponentModel>> IndexComponents => new IComponent<IndexComponentModel>[]
        {
        };

        public void InitializeServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSimpleEmailService(config =>
            {
                config.Host = "smtp.gmail.com";
                config.Port = 465;
                config.QuitAfterSending = true;
                config.UseSsl = true;
            });
        }
    }
}
