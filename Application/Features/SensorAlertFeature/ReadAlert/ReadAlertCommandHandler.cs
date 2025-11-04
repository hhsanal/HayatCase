using Application.Result.Abstract;
using Application.Result.Concrete;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Features.SensorAlertFeature.ReadAlert;

public sealed class ReadAlertCommandHandler(ISensorAlertRepository sensorAlertRepository, IUnitOfWork unitOfWork) : IRequestHandler<ReadAlertCommand, IResult>
{
    public async Task<IResult> Handle(ReadAlertCommand request, CancellationToken cancellationToken)
    {
        SensorAlert currentAlert = await sensorAlertRepository.FindAsync(sa => sa.Id == request.AlertId, cancellationToken);
        currentAlert.IsAcknowledged = true;
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new SuccessResult("Uyarı okundu olarak işaretlendi.");
    }
}
