namespace DomainModelingBuildingBlocks.Aggregates;

/// <summary>
/// Order Aggregate
/// </summary>
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
