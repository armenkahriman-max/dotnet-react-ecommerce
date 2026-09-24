using Ecommerce.Api.Application;
using Ecommerce.Api.Application.Products;
using Ecommerce.Api.Data;
using Ecommerce.Api.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(AppDbContext dbContext,
 Handler handler) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<ListProductResponse>>> GetAll()
    {
        var products = await handler.List();
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
    public async Task<ActionResult<CreateProductResponse>> Create(CreateProductRequest request)
    {
        var created = await handler.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
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