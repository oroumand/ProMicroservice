namespace NewCMSClient.Models.NewsViewModels;

public class NewsListModel
{
    public NewsListItem[] queryResult { get; set; }
    public int pageNumber { get; set; }
    public int pageSize { get; set; }
    public int totalCount { get; set; }
}

public class NewsListItem
{
    public int id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public DateTime insertDate { get; set; }
}
