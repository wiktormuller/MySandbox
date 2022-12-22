using NStorage;
using NStorage.InMemory;
using NStorage.Mongo;

var builder = WebApplication.CreateBuilder(args);

// Last write win
builder.Services
    .AddNStorage(builder.Configuration, x =>
    {
        x.AddInMemoryStorage();
        x.AddMongoStorage();
    });


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();