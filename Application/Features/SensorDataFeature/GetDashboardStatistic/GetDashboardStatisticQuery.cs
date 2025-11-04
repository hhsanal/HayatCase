using Application.Result.Abstract;
using Domain.Enums;
using MediatR;

namespace Application.Features.SensorDataFeature.GetDashboardStatistic;

public record GetDashboardStatisticQuery() : IRequest<IDataResult<DashboardStatisticVm>>;
