using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObject.Samples;

public class FirstName
{
    public string Value { get; private set; }

    public FirstName(string value)
    {
        Validate(value);
        Value = value;
    }

    private static void Validate(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ValueObjectInvalidState("Firstname can not be null");
        if (value.Length < 2)
            throw new ValueObjectInvalidState("Min lengh of first name is 2 char");
        if (value.Length > 50)
            throw new ValueObjectInvalidState("Max lengh of first name is 50 char");
    }
}

public class Student
{
    public FirstName FirstName { get; set; }
    public LastName LastName{ get; set; }
}