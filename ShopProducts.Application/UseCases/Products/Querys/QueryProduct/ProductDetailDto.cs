using ShopProducts.Domain.ValueObjects;

namespace ShopProducts.Application.UseCases.Products.Querys.QueryProduct;

public record ProductDetailDto(Guid Id, string Name, string? Description, decimal Price, QuantityInventory Inventory, bool Active);
