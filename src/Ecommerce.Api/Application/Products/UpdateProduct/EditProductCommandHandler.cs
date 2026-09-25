    using Ecommerce.Api.Data.Products;
    using Ecommerce.Api.Domain.ValueObjects;

    namespace Ecommerce.Api.Application.Products;

    public class EditProductCommandHandler(IProductRepository productRepository) 
    {

        public async Task<EditProductResponse?> Update(Guid id, EditProductRequest request)
        {
            var existing = await productRepository.GetByIdAsync(id);
            if (existing is null)
                return null;
            existing.Update(
                new ProductName(request.Name),
                new Money(request.Price),
                request.Stock,
                request.Description);


            await productRepository.UpdateAsync(existing);

            return new EditProductResponse
            {
                Id = existing.Id,
                Name = existing.Name.Value,
                Price = existing.Price.Amount,
                Stock = existing.Stock,
                Description = existing.Description
            };
        }
    }