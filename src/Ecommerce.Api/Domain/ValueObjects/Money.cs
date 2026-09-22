using Ecommerce.Api.Domain.Exceptions;

namespace Ecommerce.Api.Domain.ValueObjects;

public record Money
{
    public decimal Amount { get; }

    public Money(decimal amount)
    {
        if (amount < 0)
        throw new DomainException("Amount cannot be negative.");
        Amount = amount;
    }

    public static implicit operator decimal(Money money) =>
    money.Amount;
}