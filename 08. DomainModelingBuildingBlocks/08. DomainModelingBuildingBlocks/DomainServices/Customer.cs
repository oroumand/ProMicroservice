using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelingBuildingBlocks.DomainServices;
public enum CustomerType
{
    Gold,
    Glass,
    Silver
}
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public CustomerType CustomerType { get; set; }

}
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Weight { get; set; }
}
public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public List<OrderLine> OrderLines { get; set; }

}

public class OrderLine
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
}

public class ShippingCostCalculator
{
    public int Calculate(Customer customer, Order order)
    {

        //در این قسمت محاسبات مربوط به هزینه حمل و نقل را با توجه به داده‌هایی که در اختیار داریم انجام می‌دهیم
        return 0;
    }
}