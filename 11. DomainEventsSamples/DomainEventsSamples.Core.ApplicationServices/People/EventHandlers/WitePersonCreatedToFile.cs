using DomainEventsSamples.Core.Domain.People.Events;
using DomainEventsSamples.Framework;
using Newtonsoft.Json;

namespace DomainEventsSamples.Core.ApplicationServices.People.EventHandlers;

public class WitePersonCreatedToFile: IDomainEventHandler<PersonCreated>
{
    public  Task Hanlde(PersonCreated domainEvent)
    {
        string personCreatedstring = JsonConvert.SerializeObject(domainEvent);
        System.IO.File.WriteAllText("d:\\personCreated.txt", personCreatedstring);
        return Task.CompletedTask;
    }
}