using MediatR;
using CqrsMediatR_Demo.Entities;

namespace CqrsMediatR_Demo.Features.Customers.Commands;

public record CreateCustomerCommand(string Name, string? Email) : IRequest<Customer>;
