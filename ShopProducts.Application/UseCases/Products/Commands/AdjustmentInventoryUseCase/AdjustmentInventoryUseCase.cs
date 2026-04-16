using ShopProducts.Application.Contracts;
using ShopProducts.Application.Utils.Mediator;
using ShopProducts.Domain.Exceptions;

namespace ShopProducts.Application.UseCases.Products.Commands.AdjustmentInventoryUseCase;

public class AdjustmentInventoryUseCase(IProductRepository productRepository) : IRequestHandler<AdjustmentInventoryCommand>
{
    public async Task Handle(AdjustmentInventoryCommand request)
    {
        var product = await productRepository.GetById(request.Id);
        if (product == null)
        {
            throw new ExceptionNotFound("Product not found");
        }

        product.UpdateInventory(request.Delta);
        await productRepository.Update(product);
    }
}
