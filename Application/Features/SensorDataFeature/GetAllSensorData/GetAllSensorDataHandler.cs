using Application.Result.Abstract;
using Application.Result.Concrete;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Features.SensorDataFeature.GetAllSensorData
{
    public class GetAllSensorDataHandler(ISensorDataRepository sensorDataRepository) : IRequestHandler<GetAllSensorDataQuery, IDataResult<List<GetAllSensorDataResponse>>>
    {
        public async Task<IDataResult<List<GetAllSensorDataResponse>>> Handle(GetAllSensorDataQuery request, CancellationToken cancellationToken)
        {
            
            List<SensorData> result = await sensorDataRepository.GetAllDataWithSensorInfo();
            List<GetAllSensorDataResponse> response = result.Select(sd => new GetAllSensorDataResponse
            {
                SensorId = sd.SensorId,
                SensorCode = sd.Sensor.Code,
                TimeStamp = sd.TimeStamp,
                DelayTime = sd.DelayTime,
                unit = sd.Sensor.Unit,
                Value = sd.Value,
                isThresholdExceeded =  sd.Value > sd.Sensor.ThresholdValue
            }).ToList();
            return new SuccessDataResult<List<GetAllSensorDataResponse>>(response);
        }
    }
}
