using NewCms.Core.Contracts.NewsAgg.DAL;
using NewCms.Core.Contracts.NewsAgg.Queries.NewsLists;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.Utilities;

namespace NewCms.Core.ApplicationService.NewsAgg.Queries.NewsLists;

public class NewsListHandler : QueryHandler<NewsList, PagedData<NewsListResult>>
{
    private readonly INewsQueryRepository _repository;

    public NewsListHandler(ZaminServices zaminServices, INewsQueryRepository repository) : base(zaminServices)
    {
        _repository = repository;
    }

    public override Task<QueryResult<PagedData<NewsListResult>>> Handle(NewsList request)
    {
        var result = _repository.Query(request);
        return ResultAsync(result);
    }
}