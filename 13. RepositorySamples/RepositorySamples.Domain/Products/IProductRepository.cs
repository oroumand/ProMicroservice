using RepositorySamples.Framework;

namespace RepositorySamples.Domain.Products;
public interface IProductRepository:IRepository<Product>
{
    void Add(Product product);
}
