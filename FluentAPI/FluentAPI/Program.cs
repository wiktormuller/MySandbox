// Chain method approach - FluentAPI

using FluentAPI;

// Some examples
// var container = new ImmutableArray<>.Builder()
//     .UseContainer()
//     .UseImage("kiasaki/alpine-postgres")
//     .ExposePort(5432)
//     .WithEnvironment("POSTGRES_PASSWORD=mysecretpassword")
//     .WaitForPort("5432/tcp", 30000)
//     .Build()
//     .Start();
//     
// User user = new UserBuilder()
//     .WithLogin("Elfocrash")
//     .WithName("John Smith")
//     .Build();

// It's the naive implementation, because we don't have to pass the password and username, but it can be required.
// And the builder will still works.
var connection = new SimpleFluentSqlConnection()
    .ForServer("localhost")
    .AndDatabase("mydb")
    .AsUser("someLogin")
    .WithPassword("somePassword")
    .Connect();
    
// Extended implementation
var anotherConnection = FluentSqlConnection
    .CreateConnection(config =>
    {
        config.ConnectionName = "Some connection name";
    })
    .ForServer("localhost")
    .AndDatabase("mydb")
    .AsUser("someLogin")
    .WithPassword("somePassword")
    .Connect();