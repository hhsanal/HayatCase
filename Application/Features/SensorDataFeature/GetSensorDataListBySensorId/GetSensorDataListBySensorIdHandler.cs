using Application.Result.Abstract;
using Application.Result.Concrete;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Features.SensorDataFeature.GetSensorDataListBySensorId;

public class GetSensorDataListBySensorIdHandler(ISensorDataRepository sensorDataRepository , IFactorySensorRepository factorySensorRepository) : IRequestHandler<GetSensorDataListBySensorIdQuery, IDataResult<List<GetSensorDataListBySensorIdResponse>>>
{
    public async Task<IDataResult<List<GetSensorDataListBySensorIdResponse>>> Handle(GetSensorDataListBySensorIdQuery request, CancellationToken cancellationToken)
    {
        FactorySensor sensor = await factorySensorRepository.FindAsync(x => x.Id == request.SensorId , cancellationToken);
        List<SensorData> datas = await sensorDataRepository.GetWhere(x=>x.SensorId == request.SensorId);
        List<GetSensorDataListBySensorIdResponse> response = datas.Select(data => new GetSensorDataListBySensorIdResponse
        {
            TimeStamp = data.TimeStamp,
            DelayTime = data.DelayTime,
            Value = data.Value,
            isThresholdExceeded = data.Value >= sensor.ThresholdValue,
        }).ToList();

        return new SuccessDataResult<List<GetSensorDataListBySensorIdResponse>>(response);
    }
}
