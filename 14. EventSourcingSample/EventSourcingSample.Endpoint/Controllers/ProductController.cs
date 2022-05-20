using EventSourcingSample.Domain.Products;
using EventSourcingSample.Domain.Products.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcingSample.Endpoint.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    [HttpPost("/AddNewProduct")]
    public async Task<IActionResult> Post(long id, string name,string description,int price)
    {
        Product product = new (id, name, description, price);
        product.ChangePrice(price - 10);
        product.ChangePrice(price + 5);
        product.ChangeName(name + "test");
        product.ChangeName(name);
        _productRepository.Save(product);
        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> Post(long id)
    {
        var product = _productRepository.Get(id);
        return Ok(product);
    }
}
