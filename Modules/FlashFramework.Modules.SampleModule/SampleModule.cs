using FlashFramework.Common.Models;
using FlashFramework.Modules.SampleModule.Pages.Sample;
using FlashFramework.Modules.SampleModule.Views.Shared.Components.SampleComponent;
using FlashFramework.Shared.Modular;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlashFramework.Modules.SampleModule
{
    public class SampleModule : IModule
    {
        public string Name => "Sample Module";

        public IEnumerable<IPage> Pages => new IPage[]
        {
            new SamplePage()
        };

        public IEnumerable<IComponent<IndexComponentModel>> IndexComponents => new[]
        {
            new SampleComponent()
        };

        public void InitializeServices(IServiceCollection services, IConfiguration configuration)
        {
        }
    }
}
