using ShopProducts.Domain.Exceptions;
using ShopProducts.Domain.ValueObjects;

namespace ShopProducts.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; } = Guid.CreateVersion7();
    public string Name { get; private set; } = default!;
    public string? Description { get; private set; } = default!;
    public decimal Price { get; private set; } = default!;
    public decimal Amount { get; private set; } = default!;
    public QuantityInventory Inventory { get; private set; } = QuantityInventory.Create(0);
    public bool Active { get; private set; } = true;

    public static Product Create(string name, string? description, decimal price, decimal amount, QuantityInventory quantityInventory)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ExceptionBusinessRule("Product name is required");
        if (name.Trim().Length > 200)
            throw new ExceptionBusinessRule("Length of product name cannot exceed 200 characters");
        return new Product()
        {
            Name = name,
            Description = description,
            Price = price,
            Amount = amount,
            Inventory = quantityInventory
        };
    }

    public void UpdateInventory(int delta)
    { 
        var newInventory = Inventory.Value + delta;
        if (newInventory < 0)
            throw new ExceptionBusinessRule("Inventory cannot be negative");
        Inventory = QuantityInventory.Create(newInventory);
    }

    public void Update(string name, string? description, decimal price, decimal amount, bool active)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ExceptionBusinessRule("Product name is required");
        if (name.Trim().Length > 200)
            throw new ExceptionBusinessRule("Length of product name cannot exceed 200 characters");
        Name = name;
        Description = description;
        Price = price;
        Amount = amount;
        Active = active;
    }

    public void Delete()
    {
        Active = false;
    }
}