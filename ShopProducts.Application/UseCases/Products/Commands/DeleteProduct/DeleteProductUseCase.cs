using ShopProducts.Application.Contracts;
using ShopProducts.Application.Utils.Mediator;
using ShopProducts.Domain.Exceptions;

namespace ShopProducts.Application.UseCases.Products.Commands.DeleteProduct;

public class DeleteProductUseCase(IProductRepository productRepository) : IRequestHandler<DeleteProductCommand>
{
    public async Task Handle(DeleteProductCommand request)
    {
        var product = await productRepository.GetById(request.Id) ?? throw new ExceptionNotFound("Product not found");
        await productRepository.Delete(product.Id);
    }
}
