using MediatorFromScratch;
using MediatorFromScratch.DependencyInjection;
using MediatorFromScratch.Sample;
using Microsoft.Extensions.DependencyInjection;

// Request
// Handler
// Mediator
// Request => Mediator => Handler => Response

var serviceProvider = new ServiceCollection()
    //.AddTransient<PrintToConsoleHandler>()
    .AddMediator(ServiceLifetime.Scoped, typeof(Program))
    .BuildServiceProvider();

// var handlerDetails = new Dictionary<Type, Type>
// {
//     {typeof(PrintToConsoleRequest), typeof(PrintToConsoleHandler)}
// };

// IMediator mediator = new Mediator(serviceProvider.GetRequiredService, handlerDetails);
var mediator = serviceProvider.GetRequiredService<IMediator>();

var request = new PrintToConsoleRequest
{
    Text = "Hello from Mediator" 
};

await mediator.SendAsync(request);

var result = await mediator.SendAsync(new GiveMeAValueRequest());
