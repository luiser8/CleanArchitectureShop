using ShopProducts.Domain.Exceptions;
using ShopProducts.Domain.ValueObjects;

namespace ShopProducts.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; } = Guid.CreateVersion7();
    public string Name { get; private set; } = default!;
    public string? Description { get; private set; } = default!;
    public Money Money { get; private set; } = Money.Create(0);
    public QuantityInventory QuantityInventory { get; private set; } = QuantityInventory.Create(0);
    public bool Active { get; private set; } = true;

    public static Product Create(string name, string? description, Money money, QuantityInventory quantityInventory)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ExceptionBusinessRule("Product name is required");
        if (name.Trim().Length > 200)
            throw new ExceptionBusinessRule("Length of product name cannot exceed 200 characters");
        return new Product()
        {
            Name = name,
            Description = description,
            Money = money,
            QuantityInventory = quantityInventory
        };
    }
}