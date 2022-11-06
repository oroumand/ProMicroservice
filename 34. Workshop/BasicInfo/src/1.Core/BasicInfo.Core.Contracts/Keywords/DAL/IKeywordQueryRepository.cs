using BasicInfo.Core.Contracts.Keywords.Queries.SearchTitle;
using Zamin.Core.Contracts.Data.Queries;

namespace BasicInfo.Core.Contracts.Keywords.DAL;

public interface IKeywordQueryRepository : IQueryRepository
{

    PagedData<KeywordSearchResult> Query(TitleAndStatus titleAndStatus);
}
