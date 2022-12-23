using WorkerService;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.File(@"C:\temp\workerservice\LogFile.txt")
    .CreateLogger();

try
{
    Log.Information("Starting up the service.");

    IHost host = Host.CreateDefaultBuilder(args)
        .UseWindowsService()
        .ConfigureServices(services => { services.AddHostedService<Worker>(); })
        .UseSerilog()
        .Build();

    await host.RunAsync();

    return;
}
catch (Exception e)
{
    Log.Fatal(e, "There was a problem starting the service.");
    return;
}
finally
{
    Log.CloseAndFlush();
}