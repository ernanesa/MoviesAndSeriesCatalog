using MoviesAndSeriesCatalog.Api.Infrastructure.Data;

namespace MoviesAndSeriesCatalog.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connctionString)
    {
        services.AddSingleton(new DbConnectionFactory(connctionString));

        return services;
    }

}
