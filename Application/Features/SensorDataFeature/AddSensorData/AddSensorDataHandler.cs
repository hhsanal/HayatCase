using Application.Result.Abstract;
using Application.Result.Concrete;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;
using MediatR;

namespace Application.Features.SensorDataFeature.AddSensorData;

public class AddSensorDataHandler(ISensorDataRepository sensorDataRepository , IFactorySensorRepository factorySensorRepository, IUnitOfWork unitOfWork) : IRequestHandler<AddSensorDataCommand, IResult>
{
    public async Task<IResult> Handle(AddSensorDataCommand request, CancellationToken cancellationToken)
    {
        FactorySensor currentSensor = await factorySensorRepository.FindAsync(x=>x.Id == request.SensorId);
        if(currentSensor == null) return new ErrorResult("Sensör Veritabanına Kayıtlı Değil");
        if(!currentSensor.IsActive) return new ErrorResult("Aktif Olmayan sensörden veri alındı"); // aktif olmayan sensçrden veri alınırsa bunu kaybetmeyip loglamak gerekiyor daha sonradan eklenebilir

        SensorData addingData = new SensorData
        {
            SensorId = request.SensorId,
            TimeStamp = request.TimeStamp,
            DelayTime = DateTimeOffset.UtcNow - request.TimeStamp,
        };

        await sensorDataRepository.AddAsync(addingData , cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new SuccessResult("Sensör verisi başarıyla eklendi");
    }
}