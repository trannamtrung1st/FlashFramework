using FlashFramework.Modules.SampleModule.Components.SampleComponent;
using FlashFramework.Modules.SampleModule.Pages;
using FlashFramework.Shared.Models;
using FlashFramework.Shared.Modular;

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
    }
}
