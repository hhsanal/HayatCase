using Domain.Abstractions;
using Domain.Dtos;
using Domain.Entities;

namespace Domain.Repositories;

public interface ISensorDataRepository : IRepository<SensorData>
{
    Task<List<SensorData>> GetAllDataWithSensorInfo();
    Task<DashboardSensorDataDto> GetDashboardStats();
}
