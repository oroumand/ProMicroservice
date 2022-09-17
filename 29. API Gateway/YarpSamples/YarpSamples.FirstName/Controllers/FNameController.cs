using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace YarpSamples.FirstName.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FNameController : ControllerBase
{
    private readonly List<string> _fNames = new()
    {
        "علیرضا",
        "محمد",
        "حسین",
        "نیما",
        "امید",
        "حمید",
        "مسعود",
        "فرید",
        "رضا",
        "رامین",
    };
    private readonly Random _random = new Random();
    [HttpGet]
    public IActionResult Get()
    {
        var index = _random.Next(0, _fNames.Count - 1);
        return Ok(_fNames[index]);
    }
}
