using Domain.Enums;

namespace Application.Features.FactorySensorFeature.GetFactorySensorList;

public class GetFactorySensorListResponse
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; }
    public SensorUnit Unit { get; set; }
    public string Location { get; set; }
    public bool IsActive { get; set; }
}
