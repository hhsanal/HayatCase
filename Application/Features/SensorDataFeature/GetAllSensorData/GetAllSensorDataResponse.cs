using Domain.Enums;

namespace Application.Features.SensorDataFeature.GetAllSensorData
{
    public class GetAllSensorDataResponse
    {
        public Guid SensorId { get; set; }
        public string SensorCode { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public TimeSpan DelayTime { get; set; }
        public SensorUnit unit { get; set; }
        public decimal? Value { get; set; }
        public bool isThresholdExceeded { get; set; }
    }
}
