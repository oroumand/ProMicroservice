using Earth.Infra.Data.Sql.Queries;
using Earth.Samples.Core.Contracts.People.Queries;
using Earth.Samples.Infra.Data.Sql.Queries.Common;

namespace Earth.Samples.Infra.Data.Sql.Queries.People;

public class PersonQueryRepository : BaseQueryRepository<SampleQueryDbContext>, IPersonQueryRepository
{
    public PersonQueryRepository(SampleQueryDbContext dbContext) : base(dbContext)
    {
    }
}