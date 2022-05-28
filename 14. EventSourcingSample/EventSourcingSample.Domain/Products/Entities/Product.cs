using EventSourcingSample.Domain.Products.Events;
using EventSourcingSample.Framework;

namespace EventSourcingSample.Domain.Products.Entities;

public class Product : AggregateRoot
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public Product(IReadOnlyList<IDomainEvent> events):base(events)
    {

    }
    public Product(long id, string name, string description, int price)
    {
        //Validation and ...
        Apply(new ProductCreated(id,name,description,price));
    }

    public void ChangePrice(int newValue)
    {
        //validation
        Apply(new PriceChanged(Id, newValue));
    }

    public void ChangeName(string  newName)
    {
        //validation
        Apply(new NameChanged(Id, newName));
    }

    private void On(ProductCreated productCreated)
    {
        Id = productCreated.Id;
        Name = productCreated.Name;
        Description = productCreated.Description;
        Price = productCreated.Price;
    }
    private void On(PriceChanged priceChanged)
    {
        Price = priceChanged.Price;
    }
    private void On(NameChanged nameChanged)
    {
        Name = nameChanged.Name;
    }
}