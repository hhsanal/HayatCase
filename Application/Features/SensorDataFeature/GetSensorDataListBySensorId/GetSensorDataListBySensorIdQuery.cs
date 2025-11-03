using Application.Result.Abstract;
using MediatR;

namespace Application.Features.SensorDataFeature.GetSensorDataListBySensorId;

public sealed record GetSensorDataListBySensorIdQuery(Guid SensorId) : IRequest<IDataResult<List<GetSensorDataListBySensorIdResponse>>>;
