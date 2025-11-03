using Application.Result.Abstract;
using Domain.Enums;
using MediatR;

namespace Application.Features.FactorySensorFeature.CreateFactorySensor;

public sealed record CreateFactorySensorCommand(string Code,
                                                string Description,
                                                SensorUnit Unit,
                                                string Location) : IRequest<IResult>;
