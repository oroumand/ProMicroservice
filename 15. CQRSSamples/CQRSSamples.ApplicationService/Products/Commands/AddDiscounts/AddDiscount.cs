using CQRSSamples.Domain.Products;
using CQRSSamples.Framework;

namespace CQRSSamples.ApplicationService.Products.Commands.AddDiscounts;

public class AddDiscount : ICommand
{
    public long Id { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }
}

public class AddDiscountHandler : ICommandHandler<AddDiscount>
{
    private readonly IProductRepository _productRepository;

    public AddDiscountHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task Handle(AddDiscount command)
    {
        var p = _productRepository.Get(command.Id);
        p.AddDiscount(command.Title, command.Value);
        await _productRepository.SaveChangesAsync();
    }
}