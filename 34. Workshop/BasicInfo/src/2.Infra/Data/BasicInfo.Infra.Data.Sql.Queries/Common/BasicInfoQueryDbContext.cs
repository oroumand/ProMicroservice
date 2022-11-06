using BasicInfo.Infra.Data.Sql.Queries.Kyewords.Entities;
using Microsoft.EntityFrameworkCore;
using Zamin.Infra.Data.Sql.Queries;

namespace BasicInfo.Infra.Data.Sql.Queries.Common
{
    public class BasicInfoQueryDbContext : BaseQueryDbContext
    {
        public DbSet<Keyword> Keywords { get; set; }
        public BasicInfoQueryDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
