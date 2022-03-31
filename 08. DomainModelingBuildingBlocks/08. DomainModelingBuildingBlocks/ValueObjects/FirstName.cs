using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelingBuildingBlocks.ValueObjects;

public class FirstName
{
    public string Value { get; private set; }

    public FirstName(string value)
    {
        if(string.IsNullOrEmpty(value))
            throw new ArgumentNullException("value");
        Value = value;
    }

    public FirstName SetFirstName(string value)
    {
        return new FirstName(value);
    }
    public override bool Equals(object? obj)
    {
        var other = obj as FirstName;
        if(other == null)
            return false;
        return Value == other.Value;
    }
    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}

public class LastName
{
    public string Value { get; private set; }

    public LastName(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentNullException("value");
        Value = value;
    }

    public LastName SetLastName(string value)
    {
        return new LastName(value);
    }

    public override bool Equals(object? obj)
    {
        var other = obj as LastName;
        if (other == null)
            return false;
        return Value == other.Value;
    }
    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}