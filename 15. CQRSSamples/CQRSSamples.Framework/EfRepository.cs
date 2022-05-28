using Microsoft.EntityFrameworkCore;

namespace CQRSSamples.Framework;

public class EfCommandRepository<TAggregate, TDbContext> : ICommandRepository<TAggregate>
    where TAggregate : AggregateRoot
    where TDbContext : BaseCommandDbContext
{
    protected readonly TDbContext _dbContext;

    public EfCommandRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public TAggregate Get(long id)
    {
        var includePath = _dbContext.GetIncludePaths(typeof(TAggregate));
        IQueryable<TAggregate> query = _dbContext.Set<TAggregate>().AsQueryable();
        foreach (var item in includePath)
        {
            query = query.Include(item);
        }
        return query.Where(c => c.Id == id).First();
    }

    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
