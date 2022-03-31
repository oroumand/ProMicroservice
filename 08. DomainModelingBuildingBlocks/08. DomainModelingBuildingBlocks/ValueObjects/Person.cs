using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelingBuildingBlocks.ValueObjects;

public class Person
{
    public int Id { get; private set; }
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }

    public Person(int id, FirstName firstName, LastName lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public void SetFirstName(string firstName)
    {

        FirstName = FirstName.SetFirstName(firstName);
    }
    public void SetLastName(string lastName)
    {
        LastName = LastName.SetLastName(lastName);
    }

    public override bool Equals(object? obj)
    {
        var other = obj as Person;
        if (other == null)
            return false;

        return Id == other.Id;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}