using BasicInfo.Core.Domain.Blogs.Entities;
using Zamin.Core.Contracts.Data.Commands;

namespace BasicInfo.Core.Contracts.Blogs.CommandRepositories
{
    public interface IBlogCommandRepository:ICommandRepository<Blog>
    {
    }
}
