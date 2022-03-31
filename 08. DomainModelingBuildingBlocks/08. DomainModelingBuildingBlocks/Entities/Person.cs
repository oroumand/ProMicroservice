using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelingBuildingBlocks.Entities;

public class Person
{
    public int Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public Person(int id, string firstName, string lastName)
    {
        if(string.IsNullOrEmpty(firstName))
            throw new ArgumentNullException(nameof(firstName));
        if(string.IsNullOrEmpty(lastName))
            throw new ArgumentNullException(nameof(lastName));
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public void SetFirstName(string firstName)
    {
        if (string.IsNullOrEmpty(firstName))
            throw new ArgumentNullException(nameof(firstName));
        FirstName = firstName;
    }
    public void SetLastName(string lastName)
    {
        if (string.IsNullOrEmpty(lastName))
            throw new ArgumentNullException(nameof(lastName));
        LastName = lastName;
    }

    public override bool Equals(object? obj)
    {
        var other = obj as Person;
        if (other == null)
            return false;

        return this.Id == other.Id;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}