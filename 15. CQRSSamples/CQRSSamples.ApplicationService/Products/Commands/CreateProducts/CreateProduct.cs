using CQRSSamples.Domain.Products;
using CQRSSamples.Domain.Products.Entities;
using CQRSSamples.Framework;

namespace CQRSSamples.ApplicationService.Products.Commands.CreateProducts;

public class CreateProduct : ICommand
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public int CategoryId { get; set; }
}

public class CreateProductHandler : ICommandHandler<CreateProduct>
{
    private readonly IProductRepository _productRepository;

    public CreateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task Handle(CreateProduct command)
    {
        Product p = new(command.Title, command.Description, command.Price, command.CategoryId);
        _productRepository.Add(p);
        await _productRepository.SaveChangesAsync();
    }
}