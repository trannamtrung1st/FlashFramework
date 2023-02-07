using FlashFramework.Common.Models;
using FlashFramework.Modules.HelloWorldModule.Views.Shared.Components.HelloWorldComponent;
using FlashFramework.Shared.Modular;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlashFramework.Modules.HelloWorldModule
{
    public class HelloWorldModule : IModule
    {
        public string Name => "Hello World Module";

        public IEnumerable<IPage> Pages => new IPage[]
        {
        };

        public IEnumerable<IComponent<IndexComponentModel>> IndexComponents => new[]
        {
            new HelloWorldComponent()
        };

        public void InitializeServices(IServiceCollection services, IConfiguration configuration)
        {
        }
    }
}
