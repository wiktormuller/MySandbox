using MediatR;

namespace AssemblyScanning.Handlers;

public class GetWeatherForecastQuery : IRequest<IEnumerable<WeatherForecast>>
{
    
}