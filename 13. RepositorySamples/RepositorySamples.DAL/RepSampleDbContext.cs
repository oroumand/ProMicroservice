using Microsoft.EntityFrameworkCore;
using RepositorySamples.Domain.Categories;
using RepositorySamples.Domain.Products;
using RepositorySamples.Framework;

namespace RepositorySamples.DAL;
public class RepSampleDbContext : BaseDbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories{ get; set; }
    public RepSampleDbContext(DbContextOptions<RepSampleDbContext> options) : base(options)
    {
    }
}
