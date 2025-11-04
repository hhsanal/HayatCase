namespace Application.Features.SensorAlertFeature.GetAllAlert;

public class GetAllAlertResponse
{
    public Guid Id { get; set; }
    public Guid SensorId { get; set; }
    public string AlertType { get; set; }
    public string SensorCode { get; set; }
    public decimal Value { get; set; }
    public decimal ThresholdValue { get; set; }
    public TimeSpan DelayTime { get; set; }
    public DateTimeOffset AlertTime { get; set; }
    public bool IsAcknowledged { get; set; }
}
