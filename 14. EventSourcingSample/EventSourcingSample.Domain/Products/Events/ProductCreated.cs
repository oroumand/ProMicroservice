using EventSourcingSample.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingSample.Domain.Products.Events;

public class ProductCreated:IDomainEvent
{
    public long Id { get; }
    public string Name { get;  }
    public string Description { get;  }
    public int Price { get; }
    public ProductCreated(long id, string name, string description, int price)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
    }
}

public class PriceChanged:IDomainEvent
{
    public long Id { get; }

    public int Price { get; }
    public PriceChanged(long id,  int price)
    {
        Id = id;
        Price = price;
    }
}

public class NameChanged : IDomainEvent
{
    public long Id { get; }

    public string Name { get; }
    public NameChanged(long id, string  name)
    {
        Id = id;
        Name = name;
    }
}