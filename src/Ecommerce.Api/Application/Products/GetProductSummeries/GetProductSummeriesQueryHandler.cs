using Ecommerce.Api.Data.Products;

namespace Ecommerce.Api.Application.Products;

public class GetProductSummeriesQueryHandler(IProductRepository productRepository)
{
    public async Task<List<ProductSummaries>> ListAsync()
    {
        var items = await productRepository.ListAsync();
        return items.Select(p => new ProductSummaries
        {
            Id = p.Id,
            Name = p.Name.Value,
            Price = p.Price.Amount,
            Stock = p.Stock,
            Description = p.Description

        }).ToList();
    }

}