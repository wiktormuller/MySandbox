using AssemblyScanning.Handlers;
using AssemblyScanning.IoC;
using MediatR;

namespace AssemblyScanning.Installers;

public class MediatrInstaller : IInstaller
{
    public void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IMediator>(x => new Mediator(x.GetRequiredService));
        services.AddTransient<ISender>(x => x.GetRequiredService<IMediator>());
        services.AddTransient<IPublisher>(x => x.GetRequiredService<IMediator>());

        services.AddTransient<IRequestHandler<GetWeatherForecastQuery, IEnumerable<WeatherForecast>>, GetWeatherForecastHandler>();
    }
}