using NStorage;
using NStorage.Api;
using NStorage.InMemory;
using NStorage.Mongo;

var builder = WebApplication.CreateBuilder(args);

// Last Write Win
builder.Services
    .AddNStorage(builder.Configuration, x =>
    {
        //x.AddInMemoryStorage();
        //x.AddMongoStorage("mongo");
        // x.AddMongoStorage(x => // To get configuration from other place than appsettings
        // {
        //     x.Database = "nstorage";
        //     x.ConnectionString = "mongodb://localhost";
        // });
        
        // Thanks to the discriminator ("Type" in appsettings) only the storage based on type will be registered
        x.AddInMemoryStorage();
        x.AddMongoStorage();
        x.AddPostgresStorage(); // Our custom implementation of postgres storage
    });


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();