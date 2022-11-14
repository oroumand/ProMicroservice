using Microsoft.AspNetCore.Mvc;
using NewCMSClient.Models.Keywords;
using NewCMSClient.Models.NewsViewModels;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using IdentityModel;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using static System.Net.WebRequestMethods;

namespace NewCMSClient.Controllers;
public class NewsController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<NewsController> _logger;

    public NewsController(IHttpClientFactory httpClientFactory,ILogger<NewsController> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }
    public async Task<IActionResult> Index()
    {
        _logger.LogInformation("Start Index Pocess at {IndexRequestDateTime}",DateTime.Now);
        //var oAuthClient = _httpClientFactory.CreateClient("oAtuh");
        //var discovery = await oAuthClient.GetDiscoveryDocumentAsync();
        //var tokenResponse = await oAuthClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
        //{
        //    Address = discovery.TokenEndpoint,
        //    ClientId = "newscmsclient",
        //    ClientSecret = "newscmsclient",
        //    Scope = "basicinfo newscms"
        //});

        //string token = tokenResponse.AccessToken;
        string token = await HttpContext.GetTokenAsync("access_token");
        var newsClient = _httpClientFactory.CreateClient("news");
        newsClient.DefaultRequestHeaders.Authorization = 
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        //newsClient.SetBearerToken(token);
        string NewsAsString = await newsClient.GetStringAsync("api/News/GetList");
        NewsListModel newsList = JsonConvert.DeserializeObject<NewsListModel>(NewsAsString);
        return View(newsList);
    }

    public async Task<IActionResult> Detail(long id)
    {
        var newsClient = _httpClientFactory.CreateClient("news");
        string newsAsString = await newsClient.GetStringAsync($"api/News/GetDetail?NewsId={id}");
        NewsDetailViewModel newsDetail = JsonConvert.DeserializeObject<NewsDetailViewModel>(newsAsString);
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
