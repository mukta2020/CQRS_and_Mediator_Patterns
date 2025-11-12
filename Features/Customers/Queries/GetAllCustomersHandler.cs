using MediatR;
using CqrsMediatR_Demo.Data;
using CqrsMediatR_Demo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CqrsMediatR_Demo.Features.Customers.Queries;

public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<Customer>>
{
    private readonly AppDbContext _db;
    public GetAllCustomersHandler(AppDbContext db) => _db = db;
    public async Task<IEnumerable<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken) =>
        await _db.Customers.ToListAsync(cancellationToken);
}
