using MediatR;
using CqrsMediatR_Demo.Data;
using CqrsMediatR_Demo.Entities;

namespace CqrsMediatR_Demo.Features.Customers.Commands;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Customer>
{
    private readonly AppDbContext _db;
    public CreateCustomerHandler(AppDbContext db) => _db = db;

    public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var c = new Customer { Name = request.Name, Email = request.Email };
        _db.Customers.Add(c);
        await _db.SaveChangesAsync(cancellationToken);
        return c;
    }
}
