using CQRSSamples.Framework;

namespace CQRSSamples.Domain.Products.Entities;

public class Discount : Entity
{
    public string Title { get; private set; }
    public int Value { get; private set; }
    public Discount(string title, int value)
    {
        Title = title;
        Value = value;
    }
}
