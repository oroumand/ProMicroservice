using BasicInfo.Core.Contracts.Blogs.CommandRepositories;
using BasicInfo.Core.Domain.Blogs.Entities;
using BasicInfo.Infra.Data.Sql.Commands.Common;
using Zamin.Infra.Data.Sql.Commands;

namespace BasicInfo.Infra.Data.Sql.Commands.Blogs
{
    public class BlogCommandRepository : 
        BaseCommandRepository<Blog, BasicInfoCommandDbContext>, 
        IBlogCommandRepository
    {
        public BlogCommandRepository(BasicInfoCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}
