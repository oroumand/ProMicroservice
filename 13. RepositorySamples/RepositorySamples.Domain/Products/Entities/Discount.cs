using RepositorySamples.Framework;

namespace RepositorySamples.Domain.Products;

public class Discount:Entity
{
    public string Title { get; private set; }
    public int Value { get; private set; }
    public Discount(string title, int value)
    {
        Title=title;
        Value = value;
    }
}
