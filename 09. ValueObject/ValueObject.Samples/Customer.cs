using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObject.Samples;

public class Customer
{
    public static Customer Gold(string firstName, string lastName)
        => new Customer(firstName,lastName,CustomerType.Gold);
    public static Customer Silver(string firstName, string lastName)
    => new Customer(firstName, lastName, CustomerType.Silver);
    public Customer(string firstName, string lastName, CustomerType customerType)
    {
        FirstName = firstName;
        LastName = lastName;
        CustomerType = customerType;
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public CustomerType CustomerType { get; set; }
}
public enum CustomerType
{
    Gold,
    Silver
}
