using CQRSSamples.Domain.Categories;
using CQRSSamples.Domain.Categories.Entities;
using CQRSSamples.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSSamples.ApplicationService.Categories.Commands.CreateCategories;

public class CreateCategory: ICommand
{
    public string CategoryName { get; set; }=String.Empty;
}

public class CreateCategoryHandler : ICommandHandler<CreateCategory>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task Handle(CreateCategory command)
    {
        var category = new Category(command.CategoryName);
        _categoryRepository.Add(category);
        await _categoryRepository.SaveChangesAsync();
    }
}