using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregatesSamples.Introdutions.Orders;

public class Order
{
    public Order(int addressLineId, DateTime orderDate, List<OrderLine> orderLines)
    {
        if (addressLineId < 1)
            throw new ArgumentException();
        if(orderLines == null || !orderLines.Any())
            throw new ArgumentException();
        OrderDate = orderDate;
        _orderLines = orderLines;
        AddressLineId = addressLineId;
    }
    public int OrderId { get; set; }
    public int AddressLineId { get; set; }
    public DateTime OrderDate { get; set; }
    private  List<OrderLine> _orderLines { get; set; }
    public int GetTotalPrice()
    {
        int total = 0;
        foreach (var ol in _orderLines)
        {
            total += ol.Price;
        }
        return total;
    }


    public void ChangeCount(int newCount, int orderLineId)
    {
        var currentPrice = _orderLines.Sum(c=> c.GetTotalPrice());

    }
}
