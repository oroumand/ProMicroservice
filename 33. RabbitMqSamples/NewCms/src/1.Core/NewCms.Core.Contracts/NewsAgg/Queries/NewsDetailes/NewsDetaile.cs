using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Core.Contracts.Data.Queries;

namespace NewCms.Core.Contracts.NewsAgg.Queries.NewsDetailes;
public class NewsDetaile : IQuery<NewsDetaileResult>
{
    public long NewsId { get; set; }

}

public sealed class NewsDetaileResult
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Body { get; set; }
    public List<KeywordResult> Keywords { get; set; }
    public DateTime InsertDate { get; set; }

}

public class KeywordResult
{
    public Guid KeywordId { get; set; }
    public string KeywordTitle { get; set; }
}