using FlashFramework.Shared.Modular;
using FlashFramework.Shared.Utils;
using System.Reflection;

namespace FlashFramework.WebApp.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterModules(this IServiceCollection services,
            IEnumerable<Assembly> modules, IConfiguration configuration)
        {
            var moduleTypes = ReflectionHelper.GetAllTypesAssignableTo(typeof(IModule), modules);

            foreach (var type in moduleTypes)
            {
                IModule module = (IModule)Activator.CreateInstance(type);

                module.InitializeServices(services, configuration);

                services.AddSingleton(typeof(IModule), module);
            }

            return services;
        }
    }
}
