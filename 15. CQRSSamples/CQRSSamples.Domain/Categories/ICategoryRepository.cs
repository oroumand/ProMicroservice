using CQRSSamples.Domain.Categories.Entities;
using CQRSSamples.Framework;

namespace CQRSSamples.Domain.Categories;
public interface ICategoryRepository : ICommandRepository<Category>
{
    public void Add(Category category);
}
