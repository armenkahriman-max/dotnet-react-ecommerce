namespace Ecommerce.Api.Domain.Entities;

public abstract class Entity
{
    public Guid Id { get; protected set; } = Guid.NewGuid();

    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType()) return false;
        var other = (Entity)obj;

        return Id == other.Id;
    }
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}