using MediatR;
using CqrsMediatR_Demo.Data;
using Microsoft.EntityFrameworkCore;
using CqrsMediatR_Demo.Entities;

namespace CqrsMediatR_Demo.Features.Products.Commands;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Product?>
{
    private readonly AppDbContext _db;
    public UpdateProductHandler(AppDbContext db) => _db = db;

    public async Task<Product?> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var p = await _db.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (p is null) return null;
        p.Name = request.Name;
        p.Description = request.Description;
        p.Price = request.Price;
        await _db.SaveChangesAsync(cancellationToken);
        return p;
    }
}
