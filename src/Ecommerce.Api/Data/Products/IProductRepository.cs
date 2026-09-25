using Ecommerce.Api.Domain;

namespace Ecommerce.Api.Data.Products;

public interface IProductRepository
{
    Task<Product> AddAsync(Product product);
    Task<bool> DeleteAsync(Guid id);
    Task<Product?> GetByIdAsync(Guid id);
    Task<List<Product>> ListAsync();
    Task UpdateAsync(Product product);
}