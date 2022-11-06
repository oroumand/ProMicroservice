using BasicInfo.Core.Contracts.Keywords.DAL;
using BasicInfo.Core.Contracts.Keywords.Queries.SearchTitle;
using BasicInfo.Infra.Data.Sql.Queries.Common;
using Microsoft.EntityFrameworkCore;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.Infra.Data.Sql.Queries;

namespace BasicInfo.Infra.Data.Sql.Queries.Kyewords;

public class KeywordQueryRepository : BaseQueryRepository<BasicInfoQueryDbContext>, IKeywordQueryRepository
{
    public KeywordQueryRepository(BasicInfoQueryDbContext dbContext) : base(dbContext)
    {
    }

    public PagedData<KeywordSearchResult> Query(TitleAndStatus titleAndStatus)
    {
        PagedData<KeywordSearchResult> result = new ();
        var query = _dbContext.Keywords.AsNoTracking();

        if(titleAndStatus.Status.HasValue)
        {
            query = query.Where(c => c.Status == titleAndStatus.Status.Value);
        }

        if(!string.IsNullOrEmpty(titleAndStatus.Title))
        {
            query= query.Where(c => c.Title.StartsWith(titleAndStatus.Title));
        }
        result.QueryResult = query.OrderBy(c => c.Title).Skip(titleAndStatus.SkipCount)
                    .Take(titleAndStatus.PageSize)
                    .Select(c => new KeywordSearchResult
                    {
                        Title = c.Title,
                        Status = c.Status,
                        BusinessId = c.BusinessId,
                        Id = c.Id
                    }).ToList();


        if(titleAndStatus.NeedTotalCount)
        {
            result.TotalCount = query.Count();
        }

        return result;
    }
}