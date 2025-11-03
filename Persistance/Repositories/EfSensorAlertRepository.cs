using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories;

public class EfSensorAlertRepository : EfGenericRepository<SensorAlert>, ISensorAlertRepository
{
    public EfSensorAlertRepository(AppDbContext context) : base(context)
    {
    }

    public Task<List<SensorAlert>> GetAllAlertsWithRelationsAsync()
    {
        var result = _context.Set<SensorAlert>()
            .Include(sa => sa.SensorData)
            .ThenInclude(sd => sd.Sensor)
            .ToListAsync();
        return result;
    }
}