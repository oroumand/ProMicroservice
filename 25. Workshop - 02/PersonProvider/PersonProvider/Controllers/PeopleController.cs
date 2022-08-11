using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonProvider.Models;

namespace PersonProvider.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PeopleController : ControllerBase
{
    [HttpPost]
    public PersonResponse Post(PersonByIdRequest request)
    {
        return (new PersonResponse
        {
            Id = 1,
            Age = 1000,
            FirstName = "Alrieza",
            LastName = "Oroumand"
        });
    }
}
