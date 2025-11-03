using System.Linq.Expressions;

namespace Domain.Abstractions;

public interface IRepository<T>
{
    Task AddAsync(T Entity, CancellationToken cancellationToken = default);
    Task AddRangeAsync(List<T> EntityList, CancellationToken cancellationToken = default);
    void Update(T Entity);
    void UpdateRange(List<T> values);
    void Remove(T Entity);
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetWhere(Expression<Func<T, bool>> expression);
    Task<T> FindAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    Task<T> GetOnlyRecordAsync(CancellationToken cancellationToken = default);
}
