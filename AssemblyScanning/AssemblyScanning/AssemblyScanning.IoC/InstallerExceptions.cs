using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AssemblyScanning.IoC;

public static class InstallerExceptions
{
    public static void AddInstallersFromAssemblyContaining<TMarker>(this IServiceCollection services,
        IConfiguration configuration)
    {
        AddInstallersFromAssembliesContaining(services, configuration, typeof(TMarker));
    }

    public static void AddInstallersFromAssembliesContaining(this IServiceCollection services,
        IConfiguration configuration, params Type[] assemblyMarkers)
    {
        var assemblies = assemblyMarkers.Select(x => x.Assembly).ToArray();
        AddInstallersFromAssemblies(services, configuration, assemblies);
    }

    public static void AddInstallersFromAssemblies(this IServiceCollection services,
        IConfiguration configuration, params Assembly[] assemblies)
    {
        foreach (var assembly in assemblies)
        {
            var installerTypes = assembly.DefinedTypes.Where(x =>
                typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            var installers = installerTypes.Select(Activator.CreateInstance).Cast<IInstaller>();
            
            foreach (var installer in installers.OrderBy(x => x.Order))
            {
                installer.AddServices(services, configuration);
            }
        }
    }
}