namespace Application.Features.SensorDataFeature.GetDashboardStatistic;

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
    public int UnreadAlertCount { get; set; }
}