using Earth.Core.Domain.Exceptions;
using Earth.Samples.Core.Domain.People.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Earth.Samples.Endpoints.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PeopleController : ControllerBase
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
}
