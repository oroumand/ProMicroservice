using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelingBuildingBlocks.Factories;
public enum CustomerType
{
    Gold,
    Silver,
    Glass
}
public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public CustomerType CustomerType { get; set; }

    public static Customer CreateGoldCustomer(int id, string firstName, string lastName)
    {
        return new Customer(id,firstName,lastName,CustomerType.Gold);
    }
    public static Customer CreateSilverCustomer(int id, string firstName, string lastName)
    {
        return new Customer(id, firstName, lastName, CustomerType.Silver);
    }
    public static Customer CreateGlassCustomer(int id, string firstName, string lastName)
    {
        return new Customer(id, firstName, lastName, CustomerType.Glass);
    }
    public Customer(int id,string firstName,string lastName, CustomerType customerType)
    {

    }
}