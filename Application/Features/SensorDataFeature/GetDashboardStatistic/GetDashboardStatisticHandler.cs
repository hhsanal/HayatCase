using Application.Result.Abstract;
using Application.Result.Concrete;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Features.SensorDataFeature.GetDashboardStatistic;

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
            thresholdExceededCount = dashboardSensorStats.thresholdExceededCount,
            UnreadAlertCount = dashboardSensorStats.UnreadAlertCount
        };
        return new SuccessDataResult<DashboardStatisticVm>(dashboardStatistics);
    }
}
