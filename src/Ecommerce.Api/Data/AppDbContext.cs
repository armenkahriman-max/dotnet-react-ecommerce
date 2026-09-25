using Ecommerce.Api.Domain;
using Ecommerce.Api.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;


namespace Ecommerce.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options)
: DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(product =>
        {
            product.Property(p => p.Name)
            .HasConversion(
                name => name.Value,
                value => new ProductName(value))
                .HasMaxLength(ProductName.MaxLength);

            product.Property(p => p.Price)
        .HasConversion(
        price => price.Amount,
        amount => new Money(amount));
        });

    }
}


