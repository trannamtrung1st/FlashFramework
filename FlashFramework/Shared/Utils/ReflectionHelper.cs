using System.Reflection;

namespace FlashFramework.Shared.Utils
{
    public static class ReflectionHelper
    {
        public static IEnumerable<Type> GetTypesOfNamespace(string nameSpace, Assembly assembly = null, bool includeSubns = false)
        {
            assembly = assembly ?? Assembly.GetEntryAssembly();

            return assembly.GetTypes()
                .Where(type => includeSubns ?
                    type.Namespace == nameSpace || type.Namespace?.StartsWith(nameSpace + ".") == true :
                    type.Namespace == nameSpace);
        }

        public static List<Assembly> LoadAssemblies(string directory, string searchPattern = "*.dll")
        {
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                .ToDictionary(o => o.FullName);

            List<Assembly> allAssemblies = new List<Assembly>();

            var targetAssemblies = Directory.EnumerateFiles(directory, searchPattern, searchOption: SearchOption.TopDirectoryOnly)
                .Select(dll => new
                {
                    Dll = dll,
                    Name = SafelyGetAssemblyName(dll)
                }).Where(assObj => assObj.Name != null).ToArray();

            foreach (var assObj in targetAssemblies)
            {
                if (loadedAssemblies.ContainsKey(assObj.Name.FullName))
                {
                    allAssemblies.Add(loadedAssemblies[assObj.Name.FullName]);
                    continue;
                }

                try
                {
                    var assembly = Assembly.Load(assObj.Name);
                    allAssemblies.Add(assembly);
                }
                catch (FileNotFoundException)
                {
                    var assembly = Assembly.LoadFile(assObj.Dll);
                    allAssemblies.Add(assembly);
                }
                catch (FileLoadException) { }
                catch (BadImageFormatException) { }
            }

            return allAssemblies;
        }

        public static IEnumerable<Type> GetAllTypesAssignableTo(Type baseType, IEnumerable<Assembly> assemblies,
            bool baseTypeExcluded = true, bool isAbstract = false, bool isInterface = false)
        {
            var types = assemblies.SelectMany(o => o.GetTypes()).Where(o => baseType.IsAssignableFrom(o)
                && (!baseTypeExcluded || o != baseType) && o.IsAbstract == isAbstract
                && o.IsInterface == isInterface);

            return types;
        }

        public static AssemblyName SafelyGetAssemblyName(string assFile)
        {
            try
            {
                return AssemblyName.GetAssemblyName(assFile);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string GetEntryAssemblyLocation()
        {
            return Assembly.GetEntryAssembly().Location;
        }
    }
}
