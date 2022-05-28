using CQRSSamples.Command.DAL;
using CQRSSamples.Domain.Common;
using CQRSSamples.Framework;

namespace CQRSSamples.Command.DAL.Common;

public class EFRepositorySampleDomainUnitOfWork : BaseEfUnitOfWork<RepSampleCommandDbContext>, IRepositorySampleDomainUnitOfWork
{
    public EFRepositorySampleDomainUnitOfWork(RepSampleCommandDbContext dbContext) : base(dbContext)
    {
    }
}