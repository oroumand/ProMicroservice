using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ObservabilitySamples.API01.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly HttpClient _client;
    public PersonController(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("person");
    }
    [HttpGet(Name = "GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _client.GetStringAsync("/api/Person");
        return Ok(result);
    }
}
