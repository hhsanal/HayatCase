namespace Domain.Abstractions;

//todo result pattern oluşturulacak kalmaz bu böyle
public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
