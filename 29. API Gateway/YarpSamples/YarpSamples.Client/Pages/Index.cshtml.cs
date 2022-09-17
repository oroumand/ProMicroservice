using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace YarpSamples.Client.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public string FirstName { get; set; }
    public string LastName { get; set; }
    private readonly HttpClient _fName;
    private readonly HttpClient _lName;
    public IndexModel(ILogger<IndexModel> logger,IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _fName = httpClientFactory.CreateClient("FName");
        _lName = httpClientFactory.CreateClient("LName");
    }

    public async Task OnGet()
    {
        FirstName = await _fName.GetStringAsync("api/FName");
        LastName = await _lName.GetStringAsync("api/LName");
    }
}
