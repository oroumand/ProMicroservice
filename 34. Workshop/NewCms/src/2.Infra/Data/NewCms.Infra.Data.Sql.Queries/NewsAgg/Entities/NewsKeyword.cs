using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace NewCms.Infra.Data.Sql.Queries.NewsAgg.Entities;

public class NewsKeyword
{
    public long Id { get; set; }
    public Guid BusinessId { get; set; }
    public long NewsId { get; set; }
    //public Guid KeywordBusinessId { get; set; }
    public Keyword Keyword { get; set; }

}

public class Keyword
{
    [Key]
    public Guid KeywordBusinessId { get; set; }
    public string KeywordTitle { get; set; }
}