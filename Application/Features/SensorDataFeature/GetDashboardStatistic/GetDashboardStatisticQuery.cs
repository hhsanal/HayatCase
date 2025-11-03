using Application.Result.Abstract;
using Application.Result.Concrete;
using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;
using MediatR;

namespace Application.Features.SensorDataFeature.GetDashboardStatistic;

public record GetDashboardStatisticQuery() : IRequest<IDataResult<DashboardStatisticVm>>;

public class GetDashboardStatisticHandler(IFactorySensorRepository factorySensorRepository , ISensorDataRepository sensorDataRepository) : IRequestHandler<GetDashboardStatisticQuery, IDataResult<DashboardStatisticVm>>
{
    public async Task<IDataResult<DashboardStatisticVm>> Handle(GetDashboardStatisticQuery request, CancellationToken cancellationToken)
    {
        List<FactorySensor> sensorList = await factorySensorRepository.GetAllAsync();
        var dashboardSensorStats = await sensorDataRepository.GetDashboardStats();

        var dashboardStatistics = new DashboardStatisticVm
        {
            TotalSensorCount = sensorList.Count(),
            ActiveSensorCount = sensorList.Where(x=>x.IsActive).Count(),
            TotalDataCount = dashboardSensorStats.TotalDataCount,
            AverageReadingTemperatureValue = dashboardSensorStats.AverageReadingTemperatureValue,
            AverageReadingMoistureValue = dashboardSensorStats.AverageReadingMoistureValue,
            AverageLatency = dashboardSensorStats.AverageLatency,
            MaxTemperatureValue = dashboardSensorStats.MaxTemperatureValue,
            MinTemperatureValue = dashboardSensorStats.MinTemperatureValue,
            MaxMoistureValue = dashboardSensorStats.MaxMoistureValue,
            MinMoistureValue = dashboardSensorStats.MinMoistureValue,
            thresholdExceededCount = dashboardSensorStats.thresholdExceededCount
        };
        return new SuccessDataResult<DashboardStatisticVm>(dashboardStatistics);
    }
}
public class DashboardStatisticVm
{
    public int TotalSensorCount { get; set; }
    public int ActiveSensorCount { get; set; }
    public int TotalDataCount { get; set; }
    public decimal AverageReadingTemperatureValue { get; set; }
    public decimal AverageReadingMoistureValue { get; set; }
    public decimal AverageLatency { get; set; }
    public decimal MaxTemperatureValue { get; set; }
    public decimal MinTemperatureValue { get; set; }
    public decimal MaxMoistureValue { get; set; }
    public decimal MinMoistureValue { get; set; }
    public int thresholdExceededCount { get; set; }
}