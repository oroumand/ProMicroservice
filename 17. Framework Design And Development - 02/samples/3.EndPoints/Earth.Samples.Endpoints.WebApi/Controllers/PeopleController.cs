using Earth.Core.Domain.Exceptions;
using Earth.Endpoints.WebApi.Controllers;
using Earth.Samples.Core.Contracts.People.Commands;
using Earth.Samples.Core.Domain.People.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace Earth.Samples.Endpoints.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PeopleController : BaseController
{
    public PeopleController()
    {

    }
    [HttpGet("CheckValueObject")]
    public IActionResult CheckFirstNameValueObject(string firstName)
    {
        FirstName fname1 = new(firstName);
        FirstName fname2 = new(firstName);
        return Ok(fname1 == fname2);
    }
    [HttpGet("ExceptionCheck")]
    public IActionResult CheckFirstNameValueObject()
    {
        try
        {

            FirstName firstName = new("d");
        }
        catch (InvalidValueObjectStateException ex)
        {
            return Ok(ex.ToString());
        }
        return BadRequest();
    }
    
    [HttpPost("CreatePerson")]
    public async Task<IActionResult> CreatePerson([FromBody] CreatePerson createPerson)
    {
        return await Create<CreatePerson, long>(createPerson);
    }
}
