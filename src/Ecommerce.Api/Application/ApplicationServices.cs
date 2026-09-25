using Ecommerce.Api.Application.Products;

namespace Ecommerce.Api.Application;

public static class ApplicationServices
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddScoped<GetProductSummeriesQueryHandler>();
        service.AddScoped<GetProductDetailsQueryHandler>();
        service.AddScoped<CreateProductCommandHandler>();
        service.AddScoped<DeleteProductCommandHandler>();
        service.AddScoped<EditProductCommandHandler>();
        return service;
    }
}