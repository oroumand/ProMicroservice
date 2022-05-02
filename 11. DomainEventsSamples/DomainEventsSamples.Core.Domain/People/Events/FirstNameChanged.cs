using DomainEventsSamples.Framework;

namespace DomainEventsSamples.Core.Domain.People.Events;

public class FirstNameChanged: IDomainEvent
{
    public string FirstName { get; }
    public long Id { get; }
    public FirstNameChanged(string firstName, long id)
    {
        FirstName = firstName;
        Id = id;
    }
}
