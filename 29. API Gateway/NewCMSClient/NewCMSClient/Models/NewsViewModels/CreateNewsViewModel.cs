namespace NewCMSClient.Models.NewsViewModels;

public class CreateNewsViewModel
{
    public Guid BusunessId { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = "aaaaaa";
    public string Description { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public List<Guid> KeywordsId { get; set; }
}

public class ViewCreateNewsViewModel
{
    public CreateNewsViewModel SaveModel { get; set; }
    public Dictionary<string,string> Keywords { get; set; } = new Dictionary<string,string>();
}

