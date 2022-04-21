namespace EntitiesSample.Memento;
public class Basket
{
    private int id;
    private int cost;
    private List<BasketItem> _basketItems = new List<BasketItem>();  
    public void AddToBasket(BasketItem basketItem)
    {

    }

    public BasketSnapshot GetSnapshot()
    {
        return new BasketSnapshot
        {
            Id = id,
            Cost = cost,
        };
    }

    public void LoadSnapshot(BasketSnapshot snapshot)
    {
        id = snapshot.Id;
        cost = snapshot.Cost;
    }
}

public class BasketSnapshot
{
    public int Id { get; set; }
    public int Cost { get; set; }
}
public class BasketItem
{

}