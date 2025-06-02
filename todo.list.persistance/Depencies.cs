using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace todo.list.persistance;

public static class Dependencies
{
    public static IServiceCollection AddPersistanceDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}
