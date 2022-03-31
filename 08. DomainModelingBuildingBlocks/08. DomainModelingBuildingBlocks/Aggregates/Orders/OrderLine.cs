namespace DomainModelingBuildingBlocks.Aggregates;

public class OrderLine
{
    public int Id { get; set; }
    public Order Order { get; set; }
    public int Price { get; set; }
    public int Count { get; set; }

}