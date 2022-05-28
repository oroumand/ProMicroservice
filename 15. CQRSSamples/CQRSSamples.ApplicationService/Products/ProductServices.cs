using CQRSSamples.ApplicationService.Products.Commands.AddDiscounts;
using CQRSSamples.ApplicationService.Products.Commands.CreateProducts;
using CQRSSamples.Domain.Products;
using CQRSSamples.Domain.Products.Entities;

namespace CQRSSamples.ApplicationService.Products;

public class ProductServices
{
    private readonly IProductRepository _productRepository;

    public ProductServices(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task Handle(CreateProduct createProduct)
    {
        Product p = new(createProduct.Title, createProduct.Description, createProduct.Price, createProduct.CategoryId);
        _productRepository.Add(p);
        await _productRepository.SaveChangesAsync();
    }

    public async Task Handle(AddDiscount addDiscount)
    {
        var p = _productRepository.Get(addDiscount.Id);
        p.AddDiscount(addDiscount.Title, addDiscount.Value);
        await _productRepository.SaveChangesAsync();
    }
}