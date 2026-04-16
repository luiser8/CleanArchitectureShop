using ShopProducts.Application.Contracts;
using ShopProducts.Application.Utils.Mediator;

namespace ShopProducts.Application.UseCases.Products.Querys.FilterProducts;

public class FilterProductsUseCase(IProductRepository productRepository) : IRequestHandler<FilterProductsQuery, List<FilterProductsDto>>
{
    public async Task<List<FilterProductsDto>> Handle(FilterProductsQuery request)
    {
        var products = await productRepository.GetByFilter(request.Name, request.Active);
        return products.Select(p => p.ToFilterProductsDto()).ToList();
    }
}
