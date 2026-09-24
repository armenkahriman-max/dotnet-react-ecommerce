namespace Ecommerce.Api.Application;

public record CreateProductResponse
(Guid Id, string Name, decimal Price, string Description, int Stock);
