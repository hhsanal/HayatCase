using Application.Result.Abstract;
using MediatR;

namespace Application.Features.SensorAlertFeature.ReadAlert;

public sealed record ReadAlertCommand(Guid AlertId) : IRequest<IResult>;
