using Ecommerce.Api.Data.Products;

namespace Ecommerce.Api.Application.Products;

public class DeleteProductCommandHandler(IProductRepository productRepository)
{

    public async Task<bool> Delete(Guid id)
    {
        return await productRepository.DeleteAsync(id);
    }
}