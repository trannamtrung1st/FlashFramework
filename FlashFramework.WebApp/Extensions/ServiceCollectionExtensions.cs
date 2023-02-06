using FlashFramework.Shared.Modular;
using FlashFramework.Shared.Utils;
using System.Reflection;

namespace FlashFramework.WebApp.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IEnumerable<Assembly> LoadModules(this IServiceCollection services, IConfiguration configuration)
        {
            var modulesFolder = configuration["AppSettings__ModulesFolder"];
            var moduleAssemblies = new List<Assembly>();

            if (Directory.Exists(modulesFolder))
            {
                var allModulesContainerFolders = Directory.GetDirectories(modulesFolder);

                foreach (var folder in allModulesContainerFolders)
                {
                    var assemblies = ReflectionHelper.LoadAssemblies(
                        directory: folder,
                        searchPattern: "FlashFramework.Modules.*.dll").ToArray();

                    moduleAssemblies.AddRange(assemblies);

                    var moduleTypes = ReflectionHelper.GetAllTypesAssignableTo(typeof(IModule), assemblies);

                    foreach (var type in moduleTypes)
                    {
                        services.AddSingleton(typeof(IModule), type);
                    }
                }
            }

            return moduleAssemblies;
        }
    }
}
