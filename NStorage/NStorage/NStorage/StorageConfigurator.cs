using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NStorage;

internal sealed class StorageConfigurator : IStorageConfigurator
{
    public IServiceCollection Services { get; }
    public string Type { get; }
    private readonly IConfiguration _configuration;

    public StorageConfigurator(IServiceCollection services, IConfiguration configuration)
    {
        Services = services;
        _configuration = configuration;

        var options = GetOptions<NStorageOptions>(string.Empty);
        Type = options.Type;
    }

    public T GetOptions<T>(string sectionName) where T : class, new()
    {
        var subsection = string.IsNullOrWhiteSpace(sectionName) ? string.Empty : $":{sectionName}";
        
        var section = _configuration.GetRequiredSection($"nstorage:{subsection}");
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