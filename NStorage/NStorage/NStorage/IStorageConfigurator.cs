using Microsoft.Extensions.DependencyInjection;

namespace NStorage;

public interface IStorageConfigurator // Instead of passing IServiceCollection directly to each adapter
{
    IServiceCollection Services { get; }
    
    T GetOptions<T>(string sectionName) where T : class, new();
    
    IStorageConfigurator Register<T>() where T : class, IStorage;
}