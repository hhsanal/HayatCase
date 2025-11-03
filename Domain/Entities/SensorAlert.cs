using Domain.Abstractions;

namespace Domain.Entities;

public class SensorAlert:BaseEntity
{
    public Guid SensorDataId { get; set; }
    public SensorData SensorData { get; set; }
    public DateTimeOffset AlertTime { get; set; }
    public decimal Value { get; set; }
    public string AlertType { get; set; }
    public bool IsAcknowledged { get; set; }
}