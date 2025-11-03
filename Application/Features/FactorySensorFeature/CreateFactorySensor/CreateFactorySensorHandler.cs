using Application.Result.Abstract;
using Application.Result.Concrete;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Features.FactorySensorFeature.CreateFactorySensor;

public class CreateFactorySensorHandler(IFactorySensorRepository factorySensorRepository , IUnitOfWork unitOfWork) : IRequestHandler<CreateFactorySensorCommand, IResult>
{
    public async Task<IResult> Handle(CreateFactorySensorCommand request, CancellationToken cancellationToken)
    {
        var factorySensor = new FactorySensor
        {
            Code = request.Code,
            Description = request.Description,
            Unit = request.Unit,
            Location = request.Location
        };
        await factorySensorRepository.AddAsync(factorySensor, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new SuccessResult($"{factorySensor.Code} kodlu sensör başarıyla eklendi");
    }
}
