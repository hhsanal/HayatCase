using Domain.Dtos;
using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories;

public class EfSensorDataRepository : EfGenericRepository<SensorData>, ISensorDataRepository
{
    public EfSensorDataRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<SensorData>> GetAllDataWithSensorInfo()
    {
        var result = await _context.Set<SensorData>().Include(sd => sd.Sensor).OrderByDescending(x => x.CreatedDate).ToListAsync();
        return result;
    }

    public async Task<DashboardSensorDataDto> GetDashboardStats()
    {
        DashboardSensorDataDto dashboardSensorDataDto = new DashboardSensorDataDto();
        dashboardSensorDataDto.TotalDataCount = await _context.Set<SensorData>().CountAsync();
        dashboardSensorDataDto.thresholdExceededCount = await _context.Set<SensorData>().Where(x => x.Sensor.ThresholdValue <= x.Value).CountAsync();
        dashboardSensorDataDto.AverageReadingTemperatureValue = await _context.Set<SensorData>().Where(x => x.Sensor.Unit == SensorUnit.Celsius).AverageAsync(sd => sd.Value);
        dashboardSensorDataDto.MaxTemperatureValue = await _context.Set<SensorData>().Where(x => x.Sensor.Unit == SensorUnit.Celsius).MaxAsync(sd => sd.Value);
        dashboardSensorDataDto.MinTemperatureValue = await _context.Set<SensorData>().Where(x => x.Sensor.Unit == SensorUnit.Celsius).MinAsync(sd => sd.Value);
        dashboardSensorDataDto.AverageReadingMoistureValue = await _context.Set<SensorData>().Where(x => x.Sensor.Unit == SensorUnit.Percentage).AverageAsync(sd => sd.Value);
        dashboardSensorDataDto.MaxMoistureValue = await _context.Set<SensorData>().Where(x => x.Sensor.Unit == SensorUnit.Percentage).MaxAsync(sd => sd.Value);
        dashboardSensorDataDto.MinMoistureValue = await _context.Set<SensorData>().Where(x => x.Sensor.Unit == SensorUnit.Percentage).MinAsync(sd => sd.Value);
        dashboardSensorDataDto.AverageLatency =  (decimal) _context.Set<SensorData>().AsEnumerable().Average(x => x.DelayTime.TotalSeconds);

        return dashboardSensorDataDto;
    }
}
