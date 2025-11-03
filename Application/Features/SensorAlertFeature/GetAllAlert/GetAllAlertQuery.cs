using Application.Result.Abstract;
using MediatR;
using System;

namespace Application.Features.SensorAlertFeature.GetAllAlert;

public class GetAllAlertQuery(): IRequest<IDataResult<List<GetAllAlertResponse>>>;
