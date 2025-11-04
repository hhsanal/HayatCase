namespace SimulationWorker.Models;

public class SensorData
{
    public Guid SensorId { get; set; }
    public decimal Value { get; set; }
    public DateTimeOffset TimeStamp { get; set; }
}

public class SensorInfo
{
    public Guid SensorId { get; set; }
    public decimal MinValue { get; set; }
    public decimal MaxValue { get; set; }

}
