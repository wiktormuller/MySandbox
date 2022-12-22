using Microsoft.Extensions.DependencyInjection;

namespace NStorage.InMemory;

public static class Extensions
{
    public static IStorageConfigurator AddInMemoryStorage(this IStorageConfigurator configurator)
    {
        return configurator.Register<InMemoryStorage>();
    }
}