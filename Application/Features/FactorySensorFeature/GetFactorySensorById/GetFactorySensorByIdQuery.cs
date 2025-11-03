using Application.Result.Abstract;
using Application.Result.Concrete;
using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;
using MediatR;

namespace Application.Features.FactorySensorFeature.GetFactorySensorById;

public sealed record  GetFactorySensorByIdQuery(Guid SensorId) : IRequest<IDataResult<FactorySensorByIdResponse>>;

public class FactorySensorByIdResponse
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public SensorUnit Unit { get; set; }
    public string Location { get; set; }
    public decimal ThresholdValue { get; set; }
}

public class GetFactorySensorByIdHandler(IFactorySensorRepository factorySensorRepository) : IRequestHandler<GetFactorySensorByIdQuery, IDataResult<FactorySensorByIdResponse>>
{
    public async Task<IDataResult<FactorySensorByIdResponse>> Handle(GetFactorySensorByIdQuery request, CancellationToken cancellationToken)
    {
        FactorySensor factorySensor = await factorySensorRepository.FindAsync(x=>x.Id == request.SensorId, cancellationToken);
        FactorySensorByIdResponse response = new FactorySensorByIdResponse
        {
            Id = factorySensor.Id,
            Code = factorySensor.Code,
            Description = factorySensor.Description,
            Unit = factorySensor.Unit,
            Location = factorySensor.Location,
            ThresholdValue = factorySensor.ThresholdValue
        };
        return new SuccessDataResult<FactorySensorByIdResponse>(response);
    }
}
