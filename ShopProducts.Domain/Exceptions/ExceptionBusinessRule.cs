namespace ShopProducts.Domain.Exceptions;

public class ExceptionBusinessRule : Exception
{
    public ExceptionBusinessRule(string message) : base(message)
    {
        
    }
}