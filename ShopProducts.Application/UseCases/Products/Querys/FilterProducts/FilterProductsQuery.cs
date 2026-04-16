using ShopProducts.Application.Utils.Mediator;

namespace ShopProducts.Application.UseCases.Products.Querys.FilterProducts;

public record FilterProductsQuery(string? Name, bool? Active) : IRequest<List<FilterProductsDto>>;
