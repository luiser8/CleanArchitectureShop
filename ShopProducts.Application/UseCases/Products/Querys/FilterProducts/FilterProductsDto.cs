namespace ShopProducts.Application.UseCases.Products.Querys.FilterProducts;

public record FilterProductsDto(Guid Id, string Name, decimal Price, bool Active);
