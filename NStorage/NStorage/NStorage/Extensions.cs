using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace NStorage;

public static class Extensions
{
    public static IServiceCollection AddNStorage(this IServiceCollection services, IConfiguration configuration,
        Action<IStorageConfigurator> configurator = default)
    {
        var storageConfigurator = new StorageConfigurator(services, configuration);
        configurator?.Invoke(storageConfigurator);

        return services;
    }
}