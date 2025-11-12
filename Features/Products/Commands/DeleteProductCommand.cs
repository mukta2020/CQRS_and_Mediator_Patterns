using MediatR;

namespace CqrsMediatR_Demo.Features.Products.Commands;

public record DeleteProductCommand(int Id) : IRequest<bool>;
