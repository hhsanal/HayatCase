using Domain.Abstractions;
using Domain.Enums;

namespace Domain.Entities;

public class FactorySensor : BaseEntity
{
    public string Code { get; set; } = string.Empty; // otomasyoncular tarafından sensöre verilen projedeki kodu bu sayede onlarla ortak dil konuşulabilir.
    public string Description { get; set; }
    public SensorUnit Unit { get; set; }
    public string Location { get; set; }
    public bool IsActive { get; set; }
    public decimal ThresholdValue { get; set; }
}
