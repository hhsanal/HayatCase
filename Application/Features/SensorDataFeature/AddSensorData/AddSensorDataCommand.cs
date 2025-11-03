using Application.Result.Abstract;
using MediatR;

namespace Application.Features.SensorDataFeature.AddSensorData;

public sealed record AddSensorDataCommand(Guid SensorId , decimal Value, DateTimeOffset TimeStamp) : IRequest<IResult>;
