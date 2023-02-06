using FlashFramework.Shared.Models;

namespace FlashFramework.Shared.Modular
{
    public interface IModule
    {
        string Name { get; }
        IEnumerable<IPage> Pages { get; }
        IEnumerable<IComponent<IndexComponentModel>> IndexComponents { get; }
    }
}
