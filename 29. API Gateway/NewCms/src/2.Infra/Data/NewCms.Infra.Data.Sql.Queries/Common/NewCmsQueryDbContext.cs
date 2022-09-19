using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NewCms.Infra.Data.Sql.Queries.NewsAgg.Entities;
using Zamin.Infra.Data.Sql.Queries;

namespace NewCms.Infra.Data.Sql.Queries.Common
{
    public class NewCmsQueryDbContext : BaseQueryDbContext
    {
        public DbSet<News> News { get; set; }
        public NewCmsQueryDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
