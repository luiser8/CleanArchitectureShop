using ShopProducts.Domain.Exceptions;

namespace ShopProducts.Domain.ValueObjects;

public class Money
{
    public decimal Mount { get; private set; }
    public string Currency { get; private set; } = default!;

    private Money(decimal mount, string currency)
    {
        Mount = mount;
        Currency = currency;
    }

    public static Money Create(decimal mount, string currency = "USD")
    {
        if (mount < 0)
            throw new ExceptionBusinessRule("the amount cannot be negative");
        if (string.IsNullOrWhiteSpace(currency))
            throw new ExceptionBusinessRule("currency is required");
        return new Money(mount, currency);
    }
}