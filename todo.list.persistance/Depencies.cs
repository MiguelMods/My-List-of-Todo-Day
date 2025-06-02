using Microsoft.Extensions.DependencyInjection;

namespace todo.list.persistance;

public static class Dependencies
{
    public static IServiceCollection AddPersistanceDependencies(this IServiceCollection services)
    {
        return services;
    }
}
