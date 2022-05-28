using CQRSSamples.ApplicationService.Products.Commands.AddDiscounts;
using CQRSSamples.ApplicationService.Products.Commands.CreateProducts;
using Microsoft.AspNetCore.Mvc;

namespace RepositorySamples.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    //private readonly ProductServices _productServices;

    //public ProductsController(ProductServices productServices)
    //{
    //    _productServices = productServices;
    //}
    [HttpPost]
    public async Task<IActionResult> Post([FromServices]CreateProductHandler handler, CreateProduct createProduct)
    {
        await handler.Handle(createProduct);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromServices] AddDiscountHandler handler,  AddDiscount discount)
    {
        await handler.Handle(discount);
        return Ok();
    }
}
