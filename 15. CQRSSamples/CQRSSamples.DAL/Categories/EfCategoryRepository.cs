using CQRSSamples.Command.DAL;
using CQRSSamples.Domain.Categories;
using CQRSSamples.Domain.Categories.Entities;
using CQRSSamples.Framework;


namespace CQRSSamples.Command.DAL.Categories;

public class EfCategoryRepository : EfCommandRepository<Category, RepSampleCommandDbContext>, ICategoryRepository
{
    public EfCategoryRepository(RepSampleCommandDbContext dbContext) : base(dbContext)
    {
    }

    public void Add(Category category)
    {
        _dbContext.Categories.Add(category);
    }
}