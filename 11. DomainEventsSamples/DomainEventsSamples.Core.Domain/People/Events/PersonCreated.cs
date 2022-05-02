using DomainEventsSamples.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEventsSamples.Core.Domain.People.Events;

public class PersonCreated: IDomainEvent
{
    public string FirstName { get; }
    public string LastName { get; }
    public PersonCreated(string firstName,string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}
