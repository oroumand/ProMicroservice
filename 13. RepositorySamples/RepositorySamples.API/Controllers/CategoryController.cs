using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositorySamples.Domain.Categories;
using RepositorySamples.Domain.Common;

namespace RepositorySamples.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryController( ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    [HttpPost]
    public async Task<IActionResult> Post(string categoryName)
    {
        var category = new Category(categoryName);
        _categoryRepository.Add(category);
        await _categoryRepository.SaveChangesAsync();
        return Ok();


    }

    [HttpPut]
    public async Task<IActionResult> Put(long categoryId, string categoryName)
    {
        var category = _categoryRepository.Get(categoryId);
        category.SetName(categoryName);
        await _categoryRepository.SaveChangesAsync();
        return Ok();


    }
}
