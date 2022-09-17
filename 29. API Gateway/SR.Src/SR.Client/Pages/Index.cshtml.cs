using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Steeltoe.Common.Discovery;
using Steeltoe.Common.Http.LoadBalancer;
using Steeltoe.Common.LoadBalancer;
using Steeltoe.Discovery;
using Steeltoe.Discovery.Eureka;
using System.Xml.Linq;

namespace SR.Client.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public string FirstName { get; set; }
    DiscoveryHttpClientHandler _handler;
    public IndexModel(ILogger<IndexModel> logger,
                      IHttpClientFactory httpClientFactory,
                      IDiscoveryClient client)
    {


        _logger = logger;
        _handler = new DiscoveryHttpClientHandler(client);
    }


    public async Task OnGet()
    {
        var client = new HttpClient(_handler, false);         
        FirstName = await client.GetStringAsync("http://SR.SRC/api/FName");
    }
}
