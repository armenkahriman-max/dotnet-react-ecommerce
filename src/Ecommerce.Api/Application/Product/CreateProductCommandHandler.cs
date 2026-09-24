using Ecommerce.Api.Data;
using Ecommerce.Api.Domain;
using Ecommerce.Api.Domain.ValueObjects;

namespace Ecommerce.Api.Application;

public class CreateProductCommandHandler(AppDbContext dbContext) 
{
    public async Task<CreateProductResponse> Execute(
        CreateProductRequest request)
    {
        var name = new ProductName(request.Name);
        var price = new Money(request.Price);

        var product = new Product(name, price, request.Stock, request.Description);

        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync();

        return
        new CreateProductResponse
        {
            Id = product.Id,
            Name = product.Name.Value,
            Price = product.Price.Amount,
            Description = product.Description
        };
    }
}