using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace NStorage.Mongo;

public static class Extensions
{
    public static IStorageConfigurator AddMongoStorage(this IStorageConfigurator configurator)
    {
        var options = configurator.GetOptions<MongoStorageOptions>("mongo");
        var mongoClient = new MongoClient(options.ConnectionString);
        var database = mongoClient.GetDatabase(options.Database);
        configurator.Services.AddSingleton(database);
        
        return configurator.Register<MongoStorage>();
    }
}