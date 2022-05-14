using RepositorySamples.Domain.Products;
using RepositorySamples.Framework;

namespace RepositorySamples.DAL.Products;

public class EfProductRepository : EfRepository<Product, RepSampleDbContext>, IProductRepository
{
    public EfProductRepository(RepSampleDbContext dbContext) : base(dbContext)
    {
    }

    public void Add(Product product)
    {
        _dbContext.Products.Add(product);
    }
}