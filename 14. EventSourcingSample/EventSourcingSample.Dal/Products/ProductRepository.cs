using EventSourcingSample.Domain.Products;
using EventSourcingSample.Domain.Products.Entities;
using EventSourcingSample.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingSample.Dal.Products;

public class ProductRepository : IProductRepository
{
    private readonly IEventStore _eventStore;

    public ProductRepository(IEventStore eventStore)
    {
        _eventStore = eventStore;
    }
    public Product Get(long id)
    {
        string typeName = typeof(Product).Name;
        var events = _eventStore.Get(typeName, id);
        return new Product(events);        
    }
    public void Save(Product aggregate)
    {
        var events = aggregate.Events;
        string typeName = typeof(Product).Name;
        _eventStore.Save(typeName, aggregate.Id, aggregate.Version, events);


        //1. AggregateType
        //2. AggregateId
        //3. Event Data
        //4. eventType
        //5. DateTime


    }
}