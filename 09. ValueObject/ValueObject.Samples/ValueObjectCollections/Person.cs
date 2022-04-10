using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObject.Samples.ValueObjectCollections;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    //public List<PhoneNumber> PhoneNumbers { get; set; }
    public PhoneBook PhoneBook { get; set; }
}
public class PhoneBook
{
    public PhoneNumber HomeNumber { get; set; }
    public PhoneNumber WorkNumber { get; set; }
    public PhoneNumber FrinedNumber { get; set; }
    public PhoneBook(PhoneNumber homeNumber)
    {
        //Validate

        HomeNumber = homeNumber;
    }
    public PhoneBook(PhoneNumber homeNumber, PhoneNumber workNumber):this(homeNumber)
    {
        //Validate

        WorkNumber = workNumber;
    }
}
public class PhoneNumber
{
    public string Value { get; private set; }
    public PhoneNumber(string value)
    {
        Value = value;
    }

}