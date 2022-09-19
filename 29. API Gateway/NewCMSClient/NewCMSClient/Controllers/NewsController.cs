using Microsoft.AspNetCore.Mvc;
using NewCMSClient.Models.Keywords;
using NewCMSClient.Models.NewsViewModels;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace NewCMSClient.Controllers;
public class NewsController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public NewsController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        var biClient = _httpClientFactory.CreateClient("news");
        string KeywordAsString = await biClient.GetStringAsync("api/News/GetList");
        NewsListModel newsList = JsonConvert.DeserializeObject<NewsListModel>(KeywordAsString);
        return View(newsList);
    }

    public async Task<IActionResult> Detail(long id)
    {
        var newsClient = _httpClientFactory.CreateClient("news");
        string newsAsString = await newsClient.GetStringAsync($"api/News/GetDetail?NewsId={id}");
        NewsDetailViewModel newsDetail = JsonConvert.DeserializeObject<NewsDetailViewModel>(newsAsString);

        var biClient = _httpClientFactory.CreateClient("bi");
        string KeywordAsString = await biClient.GetStringAsync("api/Keywords/SearchTitleAndStatus");
        KeywordListResult keywordListResult = JsonConvert.DeserializeObject<KeywordListResult>(KeywordAsString);

        for (int i = 0; i < newsDetail.keywords.Count(); i++)
        {
            if (keywordListResult.queryResult.Any(c => c.businessId == newsDetail.keywords[i]))
            {
                var keyword = keywordListResult.queryResult.Where(c => c.businessId == newsDetail.keywords[i]).FirstOrDefault();
                newsDetail.keywords[i] = keyword.title;
            }
        }

        return View(newsDetail);
    }

    public async Task<IActionResult> Save()
    {
        var biClient = _httpClientFactory.CreateClient("bi");
        string KeywordAsString = await biClient.GetStringAsync("api/Keywords/SearchTitleAndStatus");
        KeywordListResult keywordListResult = JsonConvert.DeserializeObject<KeywordListResult>(KeywordAsString);
        ViewCreateNewsViewModel model = new ViewCreateNewsViewModel();

        foreach (var keyword in keywordListResult.queryResult)
        {
            model.Keywords.Add(keyword.businessId, keyword.title);
        }
        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> Save([Bind(Prefix = "SaveModel")] CreateNewsViewModel model)
    {
        var newsClient = _httpClientFactory.CreateClient("news");

        var httpContnt = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");

        var result = await newsClient.PostAsync("api/News", httpContnt);
        return result.IsSuccessStatusCode ? Redirect("Index") : Redirect("Save");
    }
}
