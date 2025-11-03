using System.Linq.Expressions;

namespace Domain.Abstractions;

public interface IRepository<T>
{
    Task AddAsync(T Entity, CancellationToken cancellationToken = default);
    Task AddRangeAsync(List<T> EntityList, CancellationToken cancellationToken = default);
    void Update(T Entity);
    void Remove(T Entity);
    Task<T> FindAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    Task<T> GetSingleRecord(CancellationToken cancellationToken = default);
    IQueryable<T> GetAll();
    IQueryable<T> GetWhere(Expression<Func<T, bool>> expression);
    Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> expression);
}
