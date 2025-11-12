using Microsoft.AspNetCore.Mvc;
using MediatR;
using CqrsMediatR_Demo.Features.Customers.Queries;
using CqrsMediatR_Demo.Features.Customers.Commands;
using CqrsMediatR_Demo.Entities;

namespace CqrsMediatR_Demo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly IMediator _mediator;
    public CustomersController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IEnumerable<Customer>> Get() => await _mediator.Send(new GetAllCustomersQuery());

    [HttpPost]
    public async Task<ActionResult<Customer>> Create(CreateCustomerCommand cmd)
    {
        var created = await _mediator.Send(cmd);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }
}
