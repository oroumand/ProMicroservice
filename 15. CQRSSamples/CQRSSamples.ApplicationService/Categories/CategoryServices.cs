using CQRSSamples.ApplicationService.Categories.Commands.CreateCategories;
using CQRSSamples.ApplicationService.Categories.Commands.UpdateCategories;
using CQRSSamples.Domain.Categories;
using CQRSSamples.Domain.Categories.Entities;

namespace CQRSSamples.ApplicationService.Categories;

public class CategoryServices
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryServices(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task Handle(CreateCategory createCategory)
    {
        var category = new Category(createCategory.CategoryName);
        _categoryRepository.Add(category);
        await _categoryRepository.SaveChangesAsync();
    }

    public async Task Handle(UpdateCategory updateCategory )
    {
        var category = _categoryRepository.Get(updateCategory.CategoryId);
        category.SetName(updateCategory.CategoryName);
        await _categoryRepository.SaveChangesAsync();
    }
}