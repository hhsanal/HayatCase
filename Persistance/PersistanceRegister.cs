using Domain.Abstractions;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;
using Persistance.Repositories;

namespace Persistance;

public static class PersistanceRegister
{
    public static IServiceCollection AddPersistanceLayer(this IServiceCollection services , IConfiguration configuration)
    {

        services.AddDbContext<AppDbContext>(conf =>
        {
            conf.UseSqlServer(configuration.GetConnectionString("HasanComputerConnection"));
        });
        services.AddScoped<IFactorySensorRepository, EfFactorySensorRepository>();
        services.AddScoped<ISensorDataRepository, EfSensorDataRepository>();
        services.AddScoped<ISensorAlertRepository, EfSensorAlertRepository>();
        services.AddScoped<IUnitOfWork>(cfr => cfr.GetRequiredService<AppDbContext>());
        return services;
    }
}
