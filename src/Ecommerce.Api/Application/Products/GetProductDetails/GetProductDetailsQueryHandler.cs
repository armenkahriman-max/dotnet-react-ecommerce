using Ecommerce.Api.Data.Products;

namespace Ecommerce.Api.Application.Products;

public class GetProductDetailsQueryHandler(IProductRepository productRepository)
{
    public async Task<GetProductDetailsResponse?> GetByIdAsync(Guid id)
    {
        var product = await productRepository.GetByIdAsync(id);
        if (product is null)
            return null;

        return new GetProductDetailsResponse
        {
            Id = product.Id,
            Name = product.Name.Value,
            Price = product.Price.Amount,
            Stock = product.Stock,
            Description = product.Description
        };
    }

}