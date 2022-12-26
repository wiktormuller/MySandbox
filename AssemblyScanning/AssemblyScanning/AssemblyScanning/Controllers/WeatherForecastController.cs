using AssemblyScanning.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AssemblyScanning.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IMediator _mediator;

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, 
        IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<ActionResult<IEnumerable<WeatherForecast>>> Get()
    {
        var query = new GetWeatherForecastQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}