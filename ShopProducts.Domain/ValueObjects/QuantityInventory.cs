using ShopProducts.Domain.Exceptions;

namespace ShopProducts.Domain.ValueObjects;

public class QuantityInventory
{
    public int Value { get; private set; }

    public QuantityInventory(int value)
    {
        Value = value;
    }

    public static QuantityInventory Create(int value)
    {
        if (value < 0)
            throw new ExceptionBusinessRule("the inventory cannot be negative");
        return new QuantityInventory(value);
    }
}