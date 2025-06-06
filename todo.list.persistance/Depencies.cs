using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using todo.list.application.Repositories.Contracts;
using todo.list.persistance.DataBaseContext;
using todo.list.persistance.Repositories.Implentations;

namespace todo.list.persistance;

public static class Dependencies
{
    public static IServiceCollection AddPersistanceDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TodoListDBContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString("defaultConnectionString"));
        });
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
