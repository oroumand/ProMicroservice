using AppArchSample.Core.ApplicationServices;
using Microsoft.AspNetCore.Mvc;

namespace AppArchSample.Endpoint.APIs.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly PersonApplicationService applicationService;

    public PersonController(PersonApplicationService applicationService)
    {
        this.applicationService = applicationService;
    }
    [HttpPost]
    public IActionResult AddPerson(CreatePersonInputDto createPersonInputDto)
    {
        applicationService.AddPerson(createPersonInputDto);
        return Ok();
    }
    [HttpPut]
    public IActionResult AddNumberToPerson(AddNumberToPersonInputDto addNumberToPerson)
    {
        applicationService.AddNumberToPerson(addNumberToPerson);
        return Ok();
    }
}
