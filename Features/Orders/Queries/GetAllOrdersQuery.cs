using MediatR;
using CqrsMediatR_Demo.Entities;

namespace CqrsMediatR_Demo.Features.Orders.Queries;

public record GetAllOrdersQuery() : IRequest<IEnumerable<Order>>;
