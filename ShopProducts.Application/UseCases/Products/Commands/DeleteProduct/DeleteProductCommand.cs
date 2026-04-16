using ShopProducts.Application.Utils.Mediator;

namespace ShopProducts.Application.UseCases.Products.Commands.DeleteProduct;

public record DeleteProductCommand(Guid Id
) : IRequest;
