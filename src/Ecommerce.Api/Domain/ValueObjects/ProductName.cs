using Ecommerce.Api.Domain.Exceptions;

namespace Ecommerce.Api.Domain.ValueObjects;

public record ProductName
{
    public const int MaxLength = 50;
    public string Value { get; }

    public ProductName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new DomainException("Product name is required.");
        }

        var cleaned = value.Trim();

        if (cleaned.Length > MaxLength)
        {
            throw new DomainException
            ($"Product name cannot be longer than {MaxLength} characters.");
        }
        Value = cleaned;
    }

    public static implicit operator string(ProductName product) =>
    product.Value;
    

    public override string ToString()
    {
        return Value;
    }
}