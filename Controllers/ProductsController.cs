using Microsoft.AspNetCore.Mvc;
using MediatR;
using CqrsMediatR_Demo.Features.Products.Queries;
using CqrsMediatR_Demo.Features.Products.Commands;
using CqrsMediatR_Demo.Entities;

namespace CqrsMediatR_Demo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProductsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IEnumerable<Product>> Get() => await _mediator.Send(new GetAllProductsQuery());

    [HttpPost]
    public async Task<ActionResult<Product>> Create(CreateProductCommand cmd)
    {
        var created = await _mediator.Send(cmd);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Product?>> Update(int id, UpdateProductCommand cmd)
    {
        if (id != cmd.Id) return BadRequest();
        var updated = await _mediator.Send(cmd);
        if (updated is null) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ok = await _mediator.Send(new DeleteProductCommand(id));
        return ok ? NoContent() : NotFound();
    }
}
