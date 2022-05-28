namespace CQRSSamples.Framework;

public class EfQueryRepository<TDbContext> : IQueryRepository
    where TDbContext : BaseQueryDbContext
{
    protected readonly TDbContext _dbContext;

    public EfQueryRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
}
