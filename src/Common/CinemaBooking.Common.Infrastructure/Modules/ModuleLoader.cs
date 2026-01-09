using System.Reflection;

namespace CinemaBooking.Common.Infrastructure.Modules;

public static class ModuleLoader
{
    public static IList<Assembly> LoadAssemblies(string modulePart)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
        var files = Directory
            .GetFiles(AppDomain.CurrentDomain.BaseDirectory, $"{modulePart}*.dll")
            .ToList();
        
        files.ForEach(x => assemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(x))));

        return assemblies;
    }
}