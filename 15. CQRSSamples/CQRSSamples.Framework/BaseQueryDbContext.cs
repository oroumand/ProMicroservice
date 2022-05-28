using Microsoft.EntityFrameworkCore;

namespace CQRSSamples.Framework;
public class BaseQueryDbContext:DbContext
{
    public BaseQueryDbContext(DbContextOptions options) : base(options)
    {
    }

    public override int SaveChanges()
    {
        throw new NotImplementedException();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();

    }
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();

    }
    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        throw new NotImplementedException();

    }

}
