using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Temp.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LNameController : ControllerBase
{
    //public LNameController(IServer server)
    //{
    //    _server = server;
    //}
    private readonly List<string> _lNames = new()
    {
        "ارومند",
        "حسینی",
        "صابری",
        "قربانی",
        "رمضانی",
        "طاهری",
        "سلیمانی",
        "کاشانی",
        "اصفهانی",
        "خداپناهی",
    };
    private readonly Random _random = new Random();
    //private readonly IServer _server;

    [HttpGet]
    public IActionResult Get()
    {

        var index = _random.Next(0, _lNames.Count - 1);
        //return Ok(_server.Features.Get<IServerAddressesFeature>().Addresses.First());
        return Ok(_lNames[index]);
    }
}
