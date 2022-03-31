using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelingBuildingBlocks.EventSourcing;

public class Person
{
    public int Id { get; private set; } 
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public Person(int id, string firstName, string lastName)
    {
        var personCreated = new PersonCreated
        {
            FirstName = firstName,
            LastName = lastName,
            Id = Id
        };
        EventPublisher.Publish(personCreated);
        On(personCreated);
    }

    public Person(List<IDomainEvent> domainEvents)
    {
        foreach (var item in domainEvents)
        {
            //On(item)
        }
    }
    public void SetFirstName(string firstName)
    {
        FirstName = firstName;
        EventPublisher.Publish(new FirstNameUpdated
        {
            FirstName = firstName,
            Id = Id
        });
    }
    public void SetLastName(string lastName)
    {
        LastName = lastName;
        EventPublisher.Publish(new LastNameUpdated
        {
            LastName = lastName,
            Id = Id
        });
    }


    public void On(PersonCreated personCreated)
    {
        Id = personCreated.Id;
        FirstName = personCreated.FirstName;
        LastName = personCreated.LastName;
    }
    public void On(FirstNameUpdated firstNameUpdated)
    {
        FirstName = firstNameUpdated.FirstName;
    }
    public void On(LastNameUpdated lastNameUpdated)
    {
        LastName = lastNameUpdated.LastName;
    }

}

public interface IDomainEvent
{

}
public class PersonCreated:IDomainEvent
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
public class FirstNameUpdated:IDomainEvent
{
    public int Id { get; set; }
    public string FirstName { get; set; }
}

public class LastNameUpdated:IDomainEvent
{
    public int Id { get; set; }
    public string LastName { get; set; }
}