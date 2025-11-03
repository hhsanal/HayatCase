using Domain.Abstractions;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
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
        services.AddScoped<IUnitOfWork>(cfr => cfr.GetRequiredService<AppDbContext>());
        return services;
    }
}

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        // Connection string (appsettings.json'dan al veya hardcode et)
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-JBOMDJF\\SEVINC; Initial Catalog=HayatCaseDb;  Integrated Security = true; TrustServerCertificate=True;");

        return new AppDbContext(optionsBuilder.Options);
    }
}
