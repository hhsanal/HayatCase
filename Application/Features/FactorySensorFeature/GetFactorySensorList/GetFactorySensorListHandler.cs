using Application.Result.Abstract;
using Application.Result.Concrete;
using Domain.Repositories;
using MediatR;

namespace Application.Features.FactorySensorFeature.GetFactorySensorList;

public class GetFactorySensorListHandler(IFactorySensorRepository factorySensorRepository) : IRequestHandler<GetFactorySensorListQuery, IDataResult<List<GetFactorySensorListResponse>>>
{
    public async Task<IDataResult<List<GetFactorySensorListResponse>>> Handle(GetFactorySensorListQuery request, CancellationToken cancellationToken)
    {
        var sensors = await factorySensorRepository.GetAllAsync();
        var response = sensors.Select(sensor => new GetFactorySensorListResponse
        {
            Id = sensor.Id,
            Code = sensor.Code,
            Description = sensor.Description,
            Unit = sensor.Unit,
            Location = sensor.Location,
            IsActive = sensor.IsActive
        }).ToList();

        return new SuccessDataResult<List<GetFactorySensorListResponse>>(response);
    }
}