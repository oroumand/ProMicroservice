using CQRSSamples.Domain.Products.Entities;
using CQRSSamples.Framework;

namespace CQRSSamples.Domain.Products;
public interface IProductRepository : ICommandRepository<Product>
{
    void Add(Product product);
}
