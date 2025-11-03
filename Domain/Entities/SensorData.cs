using Domain.Abstractions;

namespace Domain.Entities;

public class SensorData : BaseEntity
{
    public Guid SensorId { get; set; }
    public FactorySensor Sensor { get; set; }
    public DateTimeOffset TimeStamp { get; set; }
    public TimeSpan DelayTime { get; set; }
    public decimal Value { get; set; }
}
