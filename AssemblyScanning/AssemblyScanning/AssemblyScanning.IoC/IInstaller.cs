using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AssemblyScanning.IoC;

public interface IInstaller
{
    void AddServices(IServiceCollection services, IConfiguration configuration);

    public int Order => -1;
}