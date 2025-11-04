using Application.Result.Abstract;
using Application.Result.Concrete;
using Domain.Repositories;
using MediatR;

namespace Application.Features.SensorAlertFeature.GetAllAlert;

public class GetAllAlertHandler(ISensorAlertRepository sensorAlertRepository) : IRequestHandler<GetAllAlertQuery, IDataResult<List<GetAllAlertResponse>>>
{
    public async Task<IDataResult<List<GetAllAlertResponse>>> Handle(GetAllAlertQuery request, CancellationToken cancellationToken)
    {
        var result = await sensorAlertRepository.GetAllAlertsWithRelationsAsync();
        var alerts = result.Select(alert => new GetAllAlertResponse
        {
            Id = alert.Id,
            SensorId = alert.SensorData.SensorId,
            AlertType = alert.AlertType,
            SensorCode = alert.SensorData.Sensor.Code,
            Value = alert.Value,
            ThresholdValue = alert.SensorData.Sensor.ThresholdValue,
            DelayTime = alert.SensorData.DelayTime,
            AlertTime = alert.AlertTime,
            IsAcknowledged = alert.IsAcknowledged
        }).ToList();
        return new SuccessDataResult<List<GetAllAlertResponse>>(alerts);
    }
}
