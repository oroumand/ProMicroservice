using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ObservabilitySamples.API2.Models;

namespace ObservabilitySamples.API2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly PeopleContext _peopleContext;

    public PersonController(PeopleContext peopleContext)
	{
        _peopleContext = peopleContext;
    }

    [HttpGet(Name = "GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _peopleContext.People.ToListAsync());
    }
}
