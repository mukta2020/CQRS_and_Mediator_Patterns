using MediatR;
using CqrsMediatR_Demo.Entities;

namespace CqrsMediatR_Demo.Features.Orders.Commands;

public record CreateOrderCommand(int CustomerId, decimal Total) : IRequest<Order>;
