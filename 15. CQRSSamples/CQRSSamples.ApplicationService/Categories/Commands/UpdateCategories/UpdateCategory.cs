using CQRSSamples.Domain.Categories;
using CQRSSamples.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSSamples.ApplicationService.Categories.Commands.UpdateCategories;

public class UpdateCategory : ICommand
{
    public string CategoryName { get; set; }
    public long CategoryId { get; set; }
}

public class UpdateCategoryHandler : ICommandHandler<UpdateCategory>
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task Handle(UpdateCategory command)
    {
        var category = _categoryRepository.Get(command.CategoryId);
        category.SetName(command.CategoryName);
        await _categoryRepository.SaveChangesAsync();
    }
}