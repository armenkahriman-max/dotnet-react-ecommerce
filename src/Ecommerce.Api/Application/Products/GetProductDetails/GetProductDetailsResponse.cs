namespace Ecommerce.Api.Application.Products;

public class GetProductDetailsResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Description { get; set; } = "";
}