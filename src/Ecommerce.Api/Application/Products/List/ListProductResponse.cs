namespace Ecommerce.Api.Application.Products;

public record ListProductResponse
(Guid Id, string Name, decimal Price, string Description, int Stock);
