using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace NStorage.Mongo;

public static class Extensions
{
    public static IStorageConfigurator AddMongoStorage(this IStorageConfigurator configurator,
        string sectionName = "mongo")
    {
        var options = configurator.GetOptions<MongoStorageOptions>(sectionName);
        return configurator.AddMongoStorage(options);
    }

    public static IStorageConfigurator AddMongoStorage(this IStorageConfigurator configurator,
        Action<MongoStorageOptions> configure)
    {
        if (configure is null)
        {
            throw new MissingMongoStorageOptionsException();
        }
        
        var options = new MongoStorageOptions();
        configure(options);
        return configurator.AddMongoStorage(options);
    }
    
    public static IStorageConfigurator AddMongoStorage(this IStorageConfigurator configurator,
        MongoStorageOptions options)
    {
        if (options is null)
        {
            throw new MissingMongoStorageOptionsException();
        }
        
        if (configurator.Type is not "mongo")
        {
            return configurator;
        }
        
        var mongoClient = new MongoClient(options.ConnectionString);
        var database = mongoClient.GetDatabase(options.Database);
        configurator.Services.AddSingleton(database);
        
        return configurator.Register<MongoStorage>();
    }
}