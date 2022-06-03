using Earth.Infra.Data.Sql.Commands;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Earth.Samples.Infra.Data.Sql.Commands.Common;

public class SampleCommandDbContext : BaseCommandDbContext
{
    public SampleCommandDbContext(DbContextOptions<SampleCommandDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(builder);

    }
}
