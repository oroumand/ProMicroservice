using DomainEventsSamples.Core.ApplicationServices;
using DomainEventsSamples.Core.ApplicationServices.People.EventHandlers;
using DomainEventsSamples.Core.Domain.People.Events;
using DomainEventsSamples.Framework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DomainEventsSamples.Endpoints.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly PersonService _personService;

    public PersonController(PersonService personService)
    {
        _personService = personService;
    }
    [HttpPost("/CreatePerson")]
    public async Task<IActionResult> Create(string firstName,string lastName)
    {
        await _personService.AddPerson(firstName, lastName);
        return Ok();
    }

    [HttpPut("/ChangeFirstName")]
    public async Task<IActionResult> ChangeFirstName(long id, string firstName)
    {
        await _personService.SetFirstName(id,firstName);
        return Ok();
    }

    [HttpPut("/ChangeLastName")]
    public async Task<IActionResult> ChangeLastName(long id, string lastName)
    {
        await _personService.SetLasttName(id, lastName);
        return Ok();
    }
}
