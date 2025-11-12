using MediatR;
using CqrsMediatR_Demo.Entities;

namespace CqrsMediatR_Demo.Features.Products.Queries;

public record GetAllProductsQuery() : IRequest<IEnumerable<Product>>;
