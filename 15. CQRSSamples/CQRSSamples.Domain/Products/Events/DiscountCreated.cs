using CQRSSamples.Framework;

namespace CQRSSamples.Domain.Products.Events;

public class DiscountCreated : IDomainEvent
{
    public string Title { get; }
    public int Value { get; }
    public long ProductId { get; }
    public DiscountCreated(string title, int value, long productId)
    {
        Title = title;
        Value = value;
        ProductId = productId;

    }
}