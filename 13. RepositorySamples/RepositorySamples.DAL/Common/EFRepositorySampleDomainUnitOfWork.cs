using RepositorySamples.Domain.Common;
using RepositorySamples.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySamples.DAL.Common;

public class EFRepositorySampleDomainUnitOfWork : BaseEfUnitOfWork<RepSampleDbContext>, IRepositorySampleDomainUnitOfWork
{
    public EFRepositorySampleDomainUnitOfWork(RepSampleDbContext dbContext) : base(dbContext)
    {
    }
}