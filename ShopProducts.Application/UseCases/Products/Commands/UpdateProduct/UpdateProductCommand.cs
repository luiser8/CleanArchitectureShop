using ShopProducts.Application.Utils.Mediator;

namespace ShopProducts.Application.UseCases.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand
    (
        Guid Id,
        string Name,
        string? Description,
        decimal Price,
        decimal Amount,
        bool Active
    ) : IRequest;
}
