using MediatR;
using CqrsMediatR_Demo.Data;
using CqrsMediatR_Demo.Entities;

namespace CqrsMediatR_Demo.Features.Orders.Commands;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Order>
{
    private readonly AppDbContext _db;
    public CreateOrderHandler(AppDbContext db) => _db = db;

    public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order { CustomerId = request.CustomerId, Total = request.Total, CreatedAt = DateTime.UtcNow };
        _db.Orders.Add(order);
        await _db.SaveChangesAsync(cancellationToken);
        return order;
    }
}
