using EventSourcingSample.Domain.Products.Entities;
using EventSourcingSample.Framework;

namespace EventSourcingSample.Domain.Products;
public interface IProductRepository:IRepository<Product>
{
}
