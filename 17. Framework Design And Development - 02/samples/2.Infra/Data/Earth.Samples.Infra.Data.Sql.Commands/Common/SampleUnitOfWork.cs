using Earth.Infra.Data.Sql.Commands;
using Earth.Samples.Core.Contracts.Common;

namespace Earth.Samples.Infra.Data.Sql.Commands.Common;

public class SampleUnitOfWork : BaseEntityFrameworkUnitOfWork<SampleCommandDbContext>, ISampleUnitOfWork
{
    public SampleUnitOfWork(SampleCommandDbContext dbContext) : base(dbContext)
    {
    }
}