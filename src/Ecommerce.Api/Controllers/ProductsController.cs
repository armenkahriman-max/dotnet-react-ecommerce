using Ecommerce.Api.Application;
using Ecommerce.Api.Application.Products;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(
    GetProductSummeriesQueryHandler listHandler,
    GetProductDetailsQueryHandler detailsHandler,
    CreateProductCommandHandler createHandler,
    DeleteProductCommandHandler deleteHandler,
    EditProductCommandHandler editHandler) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<ProductSummaries>>> GetAll()
    {
        return Ok(await listHandler.ListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetProductDetailsResponse>> GetById(Guid id)
    {
        var product = await detailsHandler.GetByIdAsync(id);
        if (product is null)
            return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<CreateProductResponse>> Create(CreateProductRequest request)
    {
        var created = await createHandler.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await deleteHandler.Delete(id);
        if (!deleted)
            return NotFound();
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<EditProductResponse>> Update(Guid id, EditProductRequest request)
    {
        var updated = await editHandler.Update(id, request);
        if (updated is null)
            return NotFound();
        return Ok(updated);
    }
}