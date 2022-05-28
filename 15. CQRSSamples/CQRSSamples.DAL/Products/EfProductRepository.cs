using CQRSSamples.Command.DAL;
using CQRSSamples.Domain.Products;
using CQRSSamples.Domain.Products.Entities;
using CQRSSamples.Framework;

namespace CQRSSamples.Command.DAL.Products;

public class EfProductRepository : EfCommandRepository<Product, RepSampleCommandDbContext>, IProductRepository
{
    public EfProductRepository(RepSampleCommandDbContext dbContext) : base(dbContext)
    {
    }

    public void Add(Product product)
    {
        _dbContext.Products.Add(product);
    }
}