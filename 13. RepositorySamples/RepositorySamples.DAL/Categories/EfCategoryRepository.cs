using RepositorySamples.Domain.Categories;
using RepositorySamples.Framework;

namespace RepositorySamples.DAL.Categories;

public class EfCategoryRepository : EfRepository<Category, RepSampleDbContext>, ICategoryRepository
{
    public EfCategoryRepository(RepSampleDbContext dbContext) : base(dbContext)
    {
    }

    public void Add(Category category)
    {
        _dbContext.Categories.Add(category);
    }
}