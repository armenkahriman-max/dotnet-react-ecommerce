namespace Ecommerce.Api.Application.Products;

public class GetProductSummeriesRequest
{
    public int? Page { get; set; }

    public int? PageSize { get; set; }

    public string? Search { get; set; }
}