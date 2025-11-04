using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Persistance.Context;

public class AppDbContext : DbContext , IUnitOfWork
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<BaseEntity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property(x => x.CreatedDate).CurrentValue = DateTime.UtcNow;
               
            }

            if (entry.State == EntityState.Deleted)
            {
                throw new ArgumentException("Db'den direkt silme işlemi yapamazsınız");
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<FactorySensor> FactorySensors { get; set; }
    public DbSet<SensorData> SensorDatas { get; set; }
    public DbSet<SensorAlert> SensorAlerts { get; set; }
}
