namespace ShopProducts.Application.UseCases.Products.Commands.CreateProduct;

public record CreateProductCommand
(
    string Name,
    string? Description,
    decimal Money,
    string Currency,
    int QuantityInventory
);