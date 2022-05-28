using CQRSSamples.Domain.Categories.Entities;
using CQRSSamples.Domain.Products.Entities;
using CQRSSamples.Framework;
using Microsoft.EntityFrameworkCore;

namespace CQRSSamples.Command.DAL;
public class RepSampleCommandDbContext : BaseCommandDbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public RepSampleCommandDbContext(DbContextOptions<RepSampleCommandDbContext> options) : base(options)
    {
    }
}
