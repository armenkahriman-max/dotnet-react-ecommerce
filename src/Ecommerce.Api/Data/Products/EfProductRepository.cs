using Ecommerce.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api.Data.Products;

public class EfProductRepository(AppDbContext dbContext) : IProductRepository
{
    public async Task<Product> AddAsync(Product product)
    {
        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync();
        return product;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var product = await dbContext.Products.FindAsync(id);
        if (product is null)
            return false;

        dbContext.Products.Remove(product);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await dbContext.Products.FindAsync(id);
    }

    public async Task<List<Product>> ListAsync()
    {
        var product = await dbContext.Products
        .AsNoTracking()
        .ToListAsync();

        return product
        .OrderBy(p => p.Name.Value)
        .ToList();
    }

    public async Task UpdateAsync(Product product)
    {
        await dbContext.SaveChangesAsync();
    }
}