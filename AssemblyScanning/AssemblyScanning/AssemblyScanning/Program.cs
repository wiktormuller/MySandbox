using AssemblyScanning;
using AssemblyScanning.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// MediatR configuration - v1
// builder.Services.AddTransient<IMediator>(x => new Mediator(x.GetRequiredService));
// builder.Services.AddTransient<ISender>(x => x.GetRequiredService<IMediator>());
// builder.Services.AddTransient<IPublisher>(x => x.GetRequiredService<IMediator>());

// Explicit registration of handler
// builder.Services.AddTransient<IRequestHandler<GetWeatherForecastQuery, IEnumerable<WeatherForecast>>, GetWeatherForecastHandler>();

// Registering handlers via assembly scanning - v2
// builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
// builder.Services.AddMediatR(typeof(IApiAssemblyMarker).Assembly);

// Installers - v3
builder.Services.AddInstallersFromAssemblyContaining<IApiAssemblyMarker>(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();