using DomainEventsSamples.Core.Domain.People.Events;
using DomainEventsSamples.Framework;

namespace DomainEventsSamples.Core.Domain.People;
public class Person : Entity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Person(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentNullException(nameof(firstName));
        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentNullException(nameof(lastName));
        FirstName = firstName;
        LastName = lastName;
        AddEvent(new PersonCreated(FirstName, LastName));

    }
    public void ChangeFirstName(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentNullException(nameof(firstName));
        FirstName = firstName;
        AddEvent(new FirstNameChanged(FirstName, Id));
    }

    public void ChangeLastName(string lastName)
    {
        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentNullException(nameof(lastName));
        LastName = lastName;
        AddEvent(new LastNameChanged(LastName, Id));
    }
}
