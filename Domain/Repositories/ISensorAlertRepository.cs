using Domain.Abstractions;
using Domain.Entities;

namespace Domain.Repositories;

public interface ISensorAlertRepository : IRepository<SensorAlert>
{
    Task<List<SensorAlert>> GetAllAlertsWithRelationsAsync();
}
