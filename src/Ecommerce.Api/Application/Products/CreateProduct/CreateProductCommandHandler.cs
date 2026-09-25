using Ecommerce.Api.Data.Products;
using Ecommerce.Api.Domain;
using Ecommerce.Api.Domain.ValueObjects;

namespace Ecommerce.Api.Application.Products;


public class CreateProductCommandHandler(IProductRepository productRepository)
{
    public async Task<CreateProductResponse> CreateAsync(
           CreateProductRequest request)
    {
        var name = new ProductName(request.Name);
        var price = new Money(request.Price);
        var p = new Product(name, price, request.Stock, request.Description);

        await productRepository.AddAsync(p);

        return
        new CreateProductResponse
        {
            Id = p.Id,
            Name = p.Name.Value,
            Price = p.Price.Amount,
            Stock = p.Stock,
            Description = p.Description
        };

    }
}