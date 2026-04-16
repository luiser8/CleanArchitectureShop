using ShopProducts.Application.Utils.Mediator;

namespace ShopProducts.Application.UseCases.Products.Querys.QueryProduct;

public record GetByIdProductQuery(Guid Id): IRequest<ProductDetailDto>;
