namespace NStorage.Api;

public static class Extensions
{
    public static IStorageConfigurator AddPostgresStorage(this IStorageConfigurator configurator)
    {
        // Our implementation that will extend the external nugetpackage
        // if (configurator.Type is not "postgres")
        // {
        //     return configurator;
        // }
        // configurator.Services;
        // configurator.Register<>()
        
        return configurator;
    }
}