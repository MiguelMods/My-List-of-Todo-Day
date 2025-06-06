using Microsoft.Extensions.DependencyInjection;
using todo.list.application.Services.Contracs;
using todo.list.application.Services.Contracts;
using todo.list.application.Services.Implementations;

namespace todo.list.application;

public static class Dependencies
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}
