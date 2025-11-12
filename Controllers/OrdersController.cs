using Microsoft.AspNetCore.Mvc;
using MediatR;
using CqrsMediatR_Demo.Features.Orders.Queries;
using CqrsMediatR_Demo.Features.Orders.Commands;
using CqrsMediatR_Demo.Entities;

namespace CqrsMediatR_Demo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;
    public OrdersController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IEnumerable<Order>> Get() => await _mediator.Send(new GetAllOrdersQuery());

    [HttpPost]
    public async Task<ActionResult<Order>> Create(CreateOrderCommand cmd)
    {
        var created = await _mediator.Send(cmd);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }
}
