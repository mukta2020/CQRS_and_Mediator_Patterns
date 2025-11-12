using MediatR;
using CqrsMediatR_Demo.Entities;

namespace CqrsMediatR_Demo.Features.Products.Commands;

public record CreateProductCommand(string Name, string? Description, decimal Price) : IRequest<Product>;
