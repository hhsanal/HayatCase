using Domain.Enums;

namespace Application.Features.SensorDataFeature.GetSensorDataListBySensorId;

public class GetSensorDataListBySensorIdResponse
{
    public DateTimeOffset TimeStamp { get; set; }
    public TimeSpan DelayTime { get; set; }
    public SensorUnit unit { get; set; }
    public decimal? Value { get; set; }
    public bool isThresholdExceeded { get; set; }
}
