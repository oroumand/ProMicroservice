using Earth.Core.Domain.Entities;
using Earth.Core.Domain.Exceptions;
using Earth.Samples.Core.Domain.People.Events;
using Earth.Samples.Core.Domain.People.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Earth.Samples.Core.Domain.People.Entities;

public class Person:AggregateRoot
{
    #region Properties
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    #endregion


    public Person(FirstName firstName,LastName lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        AddEvent(new PersonCreated(BusinessId.Value, firstName.Value, lastName.Value));
    }

}