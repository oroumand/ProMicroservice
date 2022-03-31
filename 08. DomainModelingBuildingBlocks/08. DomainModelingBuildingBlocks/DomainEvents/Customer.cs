using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelingBuildingBlocks.DomainEvents;

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
        return new Customer(id, firstName, lastName, CustomerType.Gold);
    }
    public static Customer CreateSilverCustomer(int id, string firstName, string lastName)
    {
        return new Customer(id, firstName, lastName, CustomerType.Silver);
    }
    public static Customer CreateGlassCustomer(int id, string firstName, string lastName)
    {
        return new Customer(id, firstName, lastName, CustomerType.Glass);
    }
    public Customer(int id, string firstName, string lastName, CustomerType customerType)
    {

    }

    public void ChangeStateIfNeeded(int totalOrder)
    {
        if (totalOrder > 0 && totalOrder < 10)
        {
            CustomerType = CustomerType.Glass;
        }
        else if (totalOrder >= 10 && totalOrder < 20)
        {
            CustomerType = CustomerType.Silver;

        }
        else
        {
            CustomerType = CustomerType.Gold;
        }
    }
}


public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public List<OrderLine> orderLines { get; set; }

    public void AddProduct(int productId, int price)
    {
        if (ISSizdahBedar() && ISMoreThan100())
        {
            throw new Exception("Invalid Order");
        }
        OrderLine line = new OrderLine();
        line.Price = price;
        orderLines.Add(line);
        OrederLineitemAdded lineitemAdded = new OrederLineitemAdded
        {
            OrderId = OrderId,
            Price = price,
            ProductId = productId,
        };
        EventPublisher.Raise(lineitemAdded);
    }

    private bool ISMoreThan100()
    {
        return true;
    }

    private bool ISSizdahBedar()
    {
        return false;
    }
}

public class OrderLine
{
    public int Id { get; set; }
    public Order Order { get; set; }
    public int Price { get; set; }
    public int Count { get; set; }

}

public class OrederLineitemAdded
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Price { get; set; }
}