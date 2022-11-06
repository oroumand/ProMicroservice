namespace NewCMSClient.Models.Keywords;

public class KeywordListResult
{
    public KeywordItem[] queryResult { get; set; }
    public int pageNumber { get; set; }
    public int pageSize { get; set; }
    public int totalCount { get; set; }
}

public class KeywordItem
{
    public int id { get; set; }
    public string businessId { get; set; }
    public int status { get; set; }
    public string title { get; set; }
}
