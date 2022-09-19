using NewCms.Core.Contracts.NewsAgg.DAL;
using NewCms.Core.Contracts.NewsAgg.Queries.NewsDetailes;
using NewCms.Core.Contracts.NewsAgg.Queries.NewsLists;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.Utilities;

namespace NewCms.Core.ApplicationService.NewsAgg.Queries.NewsDetailes;

public class NewsDetailHandler : QueryHandler<NewsDetaile, NewsDetaileResult>
{
    private readonly INewsQueryRepository _repository;

    public NewsDetailHandler(ZaminServices zaminServices, INewsQueryRepository repository) : base(zaminServices)
    {
        _repository = repository;
    }

    public override Task<QueryResult<NewsDetaileResult>> Handle(NewsDetaile query)
    {
        var result = _repository.Query(query);
        return ResultAsync(result);
    }
}