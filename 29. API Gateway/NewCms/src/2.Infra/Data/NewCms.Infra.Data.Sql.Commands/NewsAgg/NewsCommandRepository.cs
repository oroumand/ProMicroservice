using NewCms.Core.Contracts.NewsAgg.DAL;
using NewCms.Core.Domain.NewsAgg.Entities;
using NewCms.Infra.Data.Sql.Commands.Common;
using Zamin.Infra.Data.Sql.Commands;

namespace NewCms.Infra.Data.Sql.Commands.NewsAgg
{
    public class NewsCommandRepository :
        BaseCommandRepository<News, NewCmsCommandDbContext>,
        INewsCommandRepository
    {
        public NewsCommandRepository(NewCmsCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}
