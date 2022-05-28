using CQRSSamples.ApplicationService.Categories;
using CQRSSamples.ApplicationService.Categories.Commands.CreateCategories;
using CQRSSamples.ApplicationService.Categories.Commands.UpdateCategories;
using Microsoft.AspNetCore.Mvc;

namespace RepositorySamples.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    //private readonly CategoryServices _categoryServices;

    //public CategoryController(CategoryServices categoryServices)
    //{
    //    _categoryServices = categoryServices;
    //}
    [HttpPost]
    public async Task<IActionResult> Post([FromServices]CreateCategoryHandler handler, CreateCategory categoryName)
    {
        await handler.Handle(categoryName);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromServices] UpdateCategoryHandler handler, UpdateCategory updateCategory)
    {
        await handler.Handle(updateCategory);
        return Ok();


    }
}
