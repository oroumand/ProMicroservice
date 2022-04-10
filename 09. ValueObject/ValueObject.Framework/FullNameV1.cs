using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObject.Framework;

public class FullNameV1 : BaseValueObjectV1<FullNameV1>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public FullNameV1(string firstName, string lastName)
    {
        //Validation

        FirstName = firstName;
        LastName = lastName;
    }
    public override int ObjectGetHashCode()
    {
        return FirstName.GetHashCode() ^ LastName.GetHashCode();
    }

    public override bool ObjectIsEqual(FullNameV1? other)
    {
       return FirstName == other.FirstName && LastName == other.LastName;
    }
}
