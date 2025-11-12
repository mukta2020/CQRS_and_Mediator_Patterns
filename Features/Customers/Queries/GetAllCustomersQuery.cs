using MediatR;
using CqrsMediatR_Demo.Entities;

namespace CqrsMediatR_Demo.Features.Customers.Queries;

public record GetAllCustomersQuery() : IRequest<IEnumerable<Customer>>;
