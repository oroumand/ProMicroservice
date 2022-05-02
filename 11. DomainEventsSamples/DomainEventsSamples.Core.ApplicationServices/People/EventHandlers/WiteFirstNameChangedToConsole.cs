using DomainEventsSamples.Core.Domain.People.Events;
using DomainEventsSamples.Framework;
using Newtonsoft.Json;

namespace DomainEventsSamples.Core.ApplicationServices.People.EventHandlers;

public class WiteFirstNameChangedToConsole : IDomainEventHandler<FirstNameChanged>
{
    public Task Hanlde(FirstNameChanged domainEvent)
    {
        string personCreatedstring = JsonConvert.SerializeObject(domainEvent);
        Console.WriteLine(personCreatedstring);
        return Task.CompletedTask;
    }
}