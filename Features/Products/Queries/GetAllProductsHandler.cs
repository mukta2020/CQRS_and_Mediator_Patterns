using MediatR;
using CqrsMediatR_Demo.Data;
using CqrsMediatR_Demo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CqrsMediatR_Demo.Features.Products.Queries;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
{
    private readonly AppDbContext _db;
    public GetAllProductsHandler(AppDbContext db) => _db = db;
    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken) =>
        await _db.Products.ToListAsync(cancellationToken);
}
