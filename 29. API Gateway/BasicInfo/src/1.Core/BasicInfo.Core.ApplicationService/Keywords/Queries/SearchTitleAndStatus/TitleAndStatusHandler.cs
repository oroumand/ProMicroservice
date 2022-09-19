using BasicInfo.Core.Contracts.Keywords.DAL;
using BasicInfo.Core.Contracts.Keywords.Queries.SearchTitle;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.Utilities;

namespace BasicInfo.Core.ApplicationService.Keywords.Queries.SearchTitleAndStatus;

public class TitleAndStatusHandler : QueryHandler<TitleAndStatus, PagedData<KeywordSearchResult>>
{
    private readonly IKeywordQueryRepository _repository;

    public TitleAndStatusHandler(ZaminServices zaminServices,IKeywordQueryRepository repository) : base(zaminServices)
    {
        _repository = repository;
    }

    public override Task<QueryResult<PagedData<KeywordSearchResult>>> Handle(TitleAndStatus request)
    {
        var result = _repository.Query(request);
        return ResultAsync(result);
    }
}