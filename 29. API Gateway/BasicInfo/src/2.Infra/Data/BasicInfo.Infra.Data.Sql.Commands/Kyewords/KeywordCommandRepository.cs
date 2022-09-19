using BasicInfo.Core.Contracts.Keywords.DAL;
using BasicInfo.Core.Domain.Keywords.Entities;
using BasicInfo.Infra.Data.Sql.Commands.Common;
using Zamin.Infra.Data.Sql.Commands;

namespace BasicInfo.Infra.Data.Sql.Commands.Kyewords;

public class KeywordCommandRepository : BaseCommandRepository<Keyword, BasicInfoCommandDbContext>,
        IKeywordCommandRepository
{
    public KeywordCommandRepository(BasicInfoCommandDbContext dbContext) : base(dbContext)
    {
    }
}