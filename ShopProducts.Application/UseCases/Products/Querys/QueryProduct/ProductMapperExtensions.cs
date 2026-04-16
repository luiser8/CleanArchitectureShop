namespace ShopProducts.Application.UseCases.Products.Querys.QueryProduct;

public static class ProductMapperExtensions
{
    public static ProductDetailDto ToProductDetailDto(this Domain.Entities.Product product)
    {
        return new ProductDetailDto(product.Id, product.Name, product.Description, product.Price, product.Inventory, product.Active);
    }
}
