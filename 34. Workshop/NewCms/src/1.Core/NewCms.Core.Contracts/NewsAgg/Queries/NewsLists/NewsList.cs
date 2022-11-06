using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Core.Contracts.Data.Queries;

namespace NewCms.Core.Contracts.NewsAgg.Queries.NewsLists;
public class NewsList : PageQuery<PagedData<NewsListResult>>
{
}

public sealed class NewsListResult
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime InsertDate { get; set; }

}