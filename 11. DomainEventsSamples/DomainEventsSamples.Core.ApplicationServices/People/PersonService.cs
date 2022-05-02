using DomainEventsSamples.Core.Domain.People;
using DomainEventsSamples.Framework;
using DomainEventsSamples.Infra.Dal;
using Microsoft.Extensions.Logging;

namespace DomainEventsSamples.Core.ApplicationServices;

public class PersonService
{
    private readonly SampleContext _ctx;
    private readonly ILogger<PersonService> _logger;

    public PersonService(SampleContext ctx, ILogger<PersonService> logger)
    {
        _ctx = ctx;
        _logger = logger;

    }
    public async Task AddPerson(string firstName, string lastName)
    {
        Person person = new(firstName, lastName);

        await _ctx.People.AddAsync(person);

        await _ctx.SaveChangesAsync();
    }
    public async Task SetFirstName(long id, string firstName)
    {
        var person = _ctx.People.FirstOrDefault(c => c.Id == id);
        person.ChangeFirstName(firstName);


        await _ctx.SaveChangesAsync();
    }

    public async Task SetLasttName(long id, string lastName)
    {
        var person = _ctx.People.FirstOrDefault(c => c.Id == id);
        person.ChangeLastName(lastName);

        await _ctx.SaveChangesAsync();
    }

}
