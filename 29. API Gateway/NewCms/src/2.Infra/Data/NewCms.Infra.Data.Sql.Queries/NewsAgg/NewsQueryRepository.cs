using Microsoft.EntityFrameworkCore;
using NewCms.Core.Contracts.NewsAgg.DAL;
using NewCms.Core.Contracts.NewsAgg.Queries.NewsDetailes;
using NewCms.Core.Contracts.NewsAgg.Queries.NewsLists;
using NewCms.Infra.Data.Sql.Queries.Common;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.Infra.Data.Sql.Queries;

namespace NewCms.Infra.Data.Sql.Queries.NewsAgg;

public class NewsQueryRepository : BaseQueryRepository<NewCmsQueryDbContext>, INewsQueryRepository
{
    public NewsQueryRepository(NewCmsQueryDbContext dbContext) : base(dbContext)
    {
    }


    public PagedData<NewsListResult> Query(NewsList newsList)
    {
        PagedData<NewsListResult> result = new();
        var query = _dbContext.News.AsNoTracking();

        result.QueryResult = query.OrderByDescending(c => c.Id).Skip(newsList.SkipCount)
                    .Take(newsList.PageSize)
                    .Select(c => new NewsListResult
                    {
                        Description = c.Description,
                        InsertDate = c.CreatedDateTime,
                        Title = c.Title,
                        Id = c.Id
                    }).ToList();


        if (newsList.NeedTotalCount)
        {
            result.TotalCount = query.Count();
        }

        return result;
    }

    public NewsDetaileResult Query(NewsDetaile newsDetaile)
    {
        return _dbContext.News.Include(c => c.NewsKeywords).Where(c => c.Id == newsDetaile.NewsId).Select(c => new NewsDetaileResult
        {
            Body = c.Body,
            Id = c.Id,
            Description = c.Description,
            InsertDate = c.CreatedDateTime,
            Title = c.Title,
            Keywords = c.NewsKeywords.Select(c => c.KeywordBusinessId).ToList(),
        }).FirstOrDefault();
    }
}