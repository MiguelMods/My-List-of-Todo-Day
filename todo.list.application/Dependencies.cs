using Microsoft.Extensions.DependencyInjection;
using todo.list.application.Services.Contracs;
using todo.list.application.Services.Implementations;

namespace todo.list.application;

public static class Dependencies
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}
