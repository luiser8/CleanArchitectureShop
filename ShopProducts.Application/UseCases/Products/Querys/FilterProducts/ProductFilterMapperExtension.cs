namespace ShopProducts.Application.UseCases.Products.Querys.FilterProducts;

public static class ProductFilterMapperExtensions
{
    public static FilterProductsDto ToFilterProductsDto(this Domain.Entities.Product product)
    {
        return new FilterProductsDto(product.Id, product.Name, product.Price, product.Active);
    }
}
