using FlashFramework.Modules.HelloWorldModule.Components.HelloWorldComponent;
using FlashFramework.Shared.Models;
using FlashFramework.Shared.Modular;

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
    }
}
