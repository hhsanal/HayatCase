using Application.Services;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Extensions;

public class SeedDataProvider(ISeedDataGenerateService seedDataGenerateService , IFactorySensorRepository factorySensorRepository , IUnitOfWork unitOfWork)
{
    public async Task SeedFactorySensorDataAsync()
    {
        List<FactorySensor> dbResult = await factorySensorRepository.GetAllAsync();
        if(dbResult.Any())
            return;
        var sensors = seedDataGenerateService.GenerateFactorySensorsAsync();
        await factorySensorRepository.AddRangeAsync(sensors);
        await unitOfWork.SaveChangesAsync();
    }
}
