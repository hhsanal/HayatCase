using Domain.Entities;
using Domain.Repositories;
using Persistance.Context;

namespace Persistance.Repositories;

public class EfFactorySensorRepository : EfGenericRepository<FactorySensor>, IFactorySensorRepository
{
    public EfFactorySensorRepository(AppDbContext context) : base(context)
    {
    }


}
