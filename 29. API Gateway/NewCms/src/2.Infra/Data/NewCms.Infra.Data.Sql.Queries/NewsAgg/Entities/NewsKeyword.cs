namespace NewCms.Infra.Data.Sql.Queries.NewsAgg.Entities;

public class NewsKeyword
{
    public long Id { get; set; }
    public Guid BusinessId { get; set; }
    public long NewsId { get; set; }
    public Guid KeywordBusinessId { get; set; }

}