using Application.Result.Abstract;
using MediatR;

namespace Application.Features.SensorDataFeature.GetAllSensorData;

public record GetAllSensorDataQuery() : IRequest<IDataResult<List<GetAllSensorDataResponse>>>;
