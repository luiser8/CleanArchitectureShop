using ShopProducts.Application.Utils.Mediator;

namespace ShopProducts.Application.UseCases.Products.Commands.CreateProduct;

public record CreateProductCommand
(
    string Name,
    string? Description,
    decimal Price,
    decimal Amount,
    int QuantityInventory
): IRequest<Guid>;