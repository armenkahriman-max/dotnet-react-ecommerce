using Ecommerce.Api.Application;
using Ecommerce.Api.Application.Products;
using Ecommerce.Api.Data;
using Ecommerce.Api.Domain;
using Ecommerce.Api.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

public class Handler(AppDbContext dbContext)
{


    public async Task<List<ListProductResponse>> List()
    {
        return await dbContext.Products
        .AsNoTracking()
        .OrderBy(p => p.Name.Value)
        .Select(p =>
            new ListProductResponse
            (
                p.Id,
                p.Name.Value,
                p.Price.Amount,
                p.Description,
                p.Stock))
                
            .ToListAsync();
    }


    public async Task<CreateProductResponse> Create(
        CreateProductRequest request)
    {
        var name = new ProductName(request.Name);
        var price = new Money(request.Price);

        var p = new Product(name, price, request.Stock, request.Description);

        dbContext.Products.Add(p);
        await dbContext.SaveChangesAsync();

        return
        new CreateProductResponse
        (
            p.Id,
            p.Name.Value,
            p.Price.Amount,
            p.Description,
            p.Stock);

    }
}

