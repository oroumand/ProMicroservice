using NewCms.Core.Contracts.NewsAgg.Queries.NewsDetailes;
using NewCms.Core.Contracts.NewsAgg.Queries.NewsLists;
using Zamin.Core.Contracts.Data.Queries;

namespace NewCms.Core.Contracts.NewsAgg.DAL;

public interface INewsQueryRepository : IQueryRepository
{
    PagedData<NewsListResult> Query(NewsList newsList);
    NewsDetaileResult Query(NewsDetaile newsDetaile);
}
