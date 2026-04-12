namespace ShopProducts.Application.UseCases.Products.Commands.CreateProduct;

public record CreateProduct
(
    string Name,
    string? Description,
    decimal Money,
    string Currency,
    int QuantityInventory
);