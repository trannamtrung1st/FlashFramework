using FlashFramework.Common.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlashFramework.Shared.Modular
{
    public interface IModule
    {
        string Name { get; }
        IEnumerable<IPage> Pages { get; }
        IEnumerable<IComponent<IndexComponentModel>> IndexComponents { get; }
        void InitializeServices(IServiceCollection services, IConfiguration configuration);
    }
}
