using RepositorySamples.Framework;

namespace RepositorySamples.Domain.Products;

public class Product:AggregateRoot
{
    public string Title { get; private set; }
    public string Description { get;private set; }
    public int Price { get; private set; }
    public int CategoryId { get; private set; }
    private List<Discount> _discounts = new();
    public IReadOnlyList<Discount> Discounts => _discounts;

    public Product(string title, string description, int price,int categoryId)
    {
        Title = title;
        Description = description;
        Price = price;
        CategoryId = categoryId;
        AddEvent(new ProductCreated(title,description,price, categoryId));
    }

    public void AddDiscount(string title,int value)
    {
        Discount discount = new Discount(title,value);
        _discounts.Add(discount);
        AddEvent(new DiscountCreated(title, value, Id));
    }
}
