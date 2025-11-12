using MediatR;
using CqrsMediatR_Demo.Data;
using CqrsMediatR_Demo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CqrsMediatR_Demo.Features.Orders.Queries;

public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<Order>>
{
    private readonly AppDbContext _db;
    public GetAllOrdersHandler(AppDbContext db) => _db = db;
    public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken) =>
        await _db.Orders.ToListAsync(cancellationToken);
}
