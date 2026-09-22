using Ecommerce.Api.Domain.Entities;
using Ecommerce.Api.Domain.ValueObjects;

namespace Ecommerce.Api.Domain;

public class Product : Entity
{
    public ProductName Name { get; private set; }
    public Money Price { get; private set; }

    public int Stock { get; private set; }
    public string Description { get; private set; }
    public Product(ProductName name, Money price, int stock, string description)
    {
        Name = name;
        Price = price;
        Stock = stock;
        Description = description;
    }

}