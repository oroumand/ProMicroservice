using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositorySamples.Domain.Products;

namespace RepositorySamples.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    [HttpPost]
    public async Task<IActionResult> Post(string title,string description, int price,int categoryId)
    {
        Product p = new(title, description, price, categoryId);
        _productRepository.Add(p);
        _productRepository.SaveChanges();
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put(long id, string title, int value)
    {
        var p = _productRepository.Get(id); 
        p.AddDiscount(title, value);
        _productRepository.SaveChanges();
        return Ok();
    }
}
