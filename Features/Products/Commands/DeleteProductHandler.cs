using MediatR;
using CqrsMediatR_Demo.Data;

namespace CqrsMediatR_Demo.Features.Products.Commands;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly AppDbContext _db;
    public DeleteProductHandler(AppDbContext db) => _db = db;

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var p = await _db.Products.FindAsync(new object[] { request.Id }, cancellationToken);
        if (p is null) return false;
        _db.Products.Remove(p);
        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}
