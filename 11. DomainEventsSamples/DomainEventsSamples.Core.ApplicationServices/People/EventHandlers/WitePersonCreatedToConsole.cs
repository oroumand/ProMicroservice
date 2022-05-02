using DomainEventsSamples.Core.Domain.People.Events;
using DomainEventsSamples.Framework;
using Newtonsoft.Json;

namespace DomainEventsSamples.Core.ApplicationServices.People.EventHandlers;

public class WitePersonCreatedToConsole: IDomainEventHandler<PersonCreated>
{
    public Task Hanlde(PersonCreated domainEvent)
    {
        string personCreatedstring = JsonConvert.SerializeObject(domainEvent);
        Console.WriteLine(domainEvent);
        return Task.CompletedTask;
    }

}
