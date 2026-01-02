using System.Reflection;

namespace CinemaBooking.Common.Infrastructure.Modules;

public static class ModuleLoader
{
    public static IList<Assembly> LoadAssemblies()
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
        var location = assemblies.Select(a => a.Location).ToArray();
        var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
            .Where(x => !location.Contains(x, StringComparer.InvariantCultureIgnoreCase))
            .ToList();
        
        files.ForEach(x => assemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(x))));
        
        return assemblies;
    }
}