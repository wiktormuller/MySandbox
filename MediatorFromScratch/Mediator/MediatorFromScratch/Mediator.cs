using System.Collections.Concurrent;

namespace MediatorFromScratch;

public class Mediator : IMediator
{
    // Thanks that func we are not binded to some implementation of IoC Container
    // So we can build the mediator like that:
    // var serviceProvider = new ServiceCollection()
    //  .AddTransient<PrintToConsoleHandler>()
    //  .BuilderServiceProvider();
    // IMediator mediator = new Mediator(serviceProvider.GetRequiredService);
    // And the Mediator package itself doesn't have to reference to any .NET packages
    private readonly Func<Type, object> _serviceResolver;

    private readonly IDictionary<Type, Type> _handlerDetails;

    public Mediator(Func<Type, object> serviceResolver, 
        IDictionary<Type, Type> handlerDetails)
    {
        _serviceResolver = serviceResolver;
        _handlerDetails = handlerDetails;
    }

    public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
    {
        var requestType = request.GetType();
        if (! _handlerDetails.ContainsKey(requestType))
        {
            throw new Exception($"No handler to handle request of type: {requestType.Name}.");
        }

        var requestHandlerType = _handlerDetails[requestType];
        var handler = _serviceResolver(requestHandlerType);

        // It compiles, but throws run-time exception
        //return await ((IHandler<IRequest<TResponse>, TResponse>)handler).HandleAsync(request);

        return await (Task<TResponse>)handler.GetType().GetMethod("HandleAsync")
            !.Invoke(handler, new[] { request });
    }
}