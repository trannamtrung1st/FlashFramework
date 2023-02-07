using FlashFramework.Shared.Utils;
using System.Reflection;

namespace FlashFramework.WebApp.Utils
{
    public static class ModuleHelper
    {
        public static IEnumerable<Assembly> LoadModules(IConfiguration configuration)
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

                    ReflectionHelper.LoadAssemblies(
                        directory: folder,
                        searchPattern: "*.dll").ToArray();

                    moduleAssemblies.AddRange(assemblies);
                }
            }

            return moduleAssemblies;
        }
    }
}
