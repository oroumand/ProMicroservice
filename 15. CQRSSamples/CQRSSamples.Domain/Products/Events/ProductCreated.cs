using CQRSSamples.Framework;

namespace CQRSSamples.Domain.Products.Events;

public class ProductCreated : IDomainEvent
{
    public string Title { get; }
    public string Description { get; }
    public int Price { get; }
    public int CategoryId { get; }
    public ProductCreated(string title, string description, int price, int categoryId)
    {
        Title = title;
        Description = description;
        Price = price;
        CategoryId = categoryId;
    }
}
