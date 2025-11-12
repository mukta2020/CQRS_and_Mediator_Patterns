using MediatR;
using CqrsMediatR_Demo.Entities;

namespace CqrsMediatR_Demo.Features.Products.Commands;

public record UpdateProductCommand(int Id, string Name, string? Description, decimal Price) : IRequest<Product?>;
