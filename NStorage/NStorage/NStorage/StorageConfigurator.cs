using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NStorage;

internal sealed class StorageConfigurator : IStorageConfigurator
{
    public IServiceCollection Services { get; }
    private readonly IConfiguration _configuration;

    public StorageConfigurator(IServiceCollection services, IConfiguration configuration)
    {
        Services = services;
        _configuration = configuration;
    }

    public T GetOptions<T>(string sectionName) where T : class, new()
    {
        var section = _configuration.GetRequiredSection($"nstorage:{sectionName}");
        var options = new T();
        section.Bind(options);

        return options;
    }

    public IStorageConfigurator Register<T>() where T : class, IStorage
    {
        Services.AddSingleton<IStorage, T>();
        return this;
    }
}