namespace AggregatesSamples.Introdutions.Orders;

public class OrderLine:Entity
{
    public int LineId { get; private set; }
    public int ProductId { get; private set; }
    public int Price { get; private set; }
    public int Count { get; private  set; }

    public void ChangeCount(int newCount)
    {
        if (newCount < 0)
            throw new ArgumentException();
        if(GetTotalPrice() > 5000)
        {
            throw new ArgumentException();
        }
        Count = newCount;
    }

    public int GetTotalPrice() => Price * Count;

}
