using ShopProducts.Application.Utils.Mediator;

namespace ShopProducts.Application.UseCases.Products.Commands.AdjustmentInventoryUseCase;

    public record AdjustmentInventoryCommand(
        Guid Id,
        int Delta
    ) : IRequest;
