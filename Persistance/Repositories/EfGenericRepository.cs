using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System.Linq.Expressions;

namespace Persistance.Repositories;

public class EfGenericRepository<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext _context;
    public EfGenericRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(T Entity, CancellationToken cancellationToken = default)
    {
        await _context.Set<T>().AddAsync(Entity, cancellationToken);
    }

    public async Task AddRangeAsync(List<T> EntityList, CancellationToken cancellationToken = default)
    {
        await _context.Set<T>().AddRangeAsync(EntityList, cancellationToken);
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().AsNoTracking().AnyAsync(expression, cancellationToken);
    }

    public async Task<T> GetOnlyRecordAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<T> FindAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(expression, cancellationToken);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<List<T>> GetWhere(Expression<Func<T, bool>> expression)
    {
        return await _context.Set<T>().AsNoTracking().Where(expression).ToListAsync();
    }
    public void Remove(T Entity)
    {
        _context.Entry(Entity).State = EntityState.Deleted;
    }

    public void Update(T Entity)
    {
        _context.Entry(Entity).State = EntityState.Modified;
    }
    public void UpdateRange(List<T> Entities)
    {
        foreach (var item in Entities)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }

}
