using Application.Result.Abstract;
using MediatR;

namespace Application.Features.FactorySensorFeature.GetFactorySensorList;

public class GetFactorySensorListQuery() : IRequest<IDataResult<List<GetFactorySensorListResponse>>>;
