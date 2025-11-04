using Domain.Entities;

namespace Application.Services;

public interface ISeedDataGenerateService
{
    List<FactorySensor> GenerateFactorySensorsAsync();
}
