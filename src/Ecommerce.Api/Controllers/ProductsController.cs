using Ecommerce.Api.Data;
using Ecommerce.Api.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(AppDbContext dbContext) : ControllerBase //here
{
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAll()
    {
        var products = await dbContext.Products
        .OrderBy(product => product.Name)
        .ToListAsync();

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var product = await dbContext.Products.FindAsync(id);
        if (product is null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult> Create(Product product)
    {
        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var product = await dbContext.Products.FindAsync(id);
        if (product is null)
        {
            return NotFound();
        }
        dbContext.Products.Remove(product);
        await dbContext.SaveChangesAsync();

        return NoContent();

    }
  
}