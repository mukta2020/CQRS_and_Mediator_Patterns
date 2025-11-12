using MediatR;
using CqrsMediatR_Demo.Data;
using CqrsMediatR_Demo.Entities;

namespace CqrsMediatR_Demo.Features.Products.Commands;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, Product>
{
    private readonly AppDbContext _db;
    public CreateProductHandler(AppDbContext db) => _db = db;

    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var p = new Product { Name = request.Name, Description = request.Description, Price = request.Price };
        _db.Products.Add(p);
        await _db.SaveChangesAsync(cancellationToken);
        return p;
    }
}
