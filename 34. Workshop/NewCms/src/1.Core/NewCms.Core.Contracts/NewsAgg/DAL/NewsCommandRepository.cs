using NewCms.Core.Domain.NewsAgg.Entities;
using Zamin.Core.Contracts.Data.Commands;

namespace NewCms.Core.Contracts.NewsAgg.DAL
{
    public interface INewsCommandRepository : ICommandRepository<News>
    {
    }
}
