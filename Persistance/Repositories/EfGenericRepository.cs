using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System.Linq.Expressions;

namespace Persistance.Repositories;

public class EfGenericRepository<T>(AppDbContext _context) : IRepository<T> where T : class
{
    public async Task AddAsync(T Entity, CancellationToken cancellationToken = default)
    {
        await _context.Set<T>().AddAsync(Entity, cancellationToken);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(List<T> EntityList, CancellationToken cancellationToken = default)
    {
        await _context.Set<T>().AddRangeAsync(EntityList, cancellationToken);
        await _context.SaveChangesAsync();
    }

    public async Task<T> FindAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().Where(expression).FirstOrDefaultAsync(cancellationToken);

    }
    public async Task<T> GetSingleRecord(CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(cancellationToken);

    }
    public IQueryable<T> GetAll()
    {

        return _context.Set<T>().AsNoTracking().AsQueryable();
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression).AsNoTracking().AsQueryable();

    }

    public void Remove(T Entity)
    {
        _context.Remove(Entity);
        _context.SaveChanges();
    }

    public void Update(T Entity)
    {
        _context.Update(Entity);
        _context.SaveChanges();
    }
    public async Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> expression)
    {
        return await _context.Set<T>().Where(expression).AsNoTracking().ToListAsync();
    }
}
