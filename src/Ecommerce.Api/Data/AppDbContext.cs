using Ecommerce.Api.Domain;
using Microsoft.EntityFrameworkCore;
namespace Ecommerce.Api.Data;



public class AppDbContext(DbContextOptions<AppDbContext> options)
: DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
}

