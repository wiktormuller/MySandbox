using Microsoft.Extensions.DependencyInjection;

namespace NStorage.InMemory;

public static class Extensions
{
    public static IStorageConfigurator AddInMemoryStorage(this IStorageConfigurator configurator)
    {
        if (configurator.Type is "inMemory")
        {
            return configurator.Register<InMemoryStorage>();
        }

        return configurator;
    }
}