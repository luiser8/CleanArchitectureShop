namespace ShopProducts.Domain.Exceptions;

public class ExceptionBusinessRule : Exception
{
    public ExceptionBusinessRule(string message) : base(message)
    {
        
    }
}

public class ExceptionNotFound : Exception
{
    public ExceptionNotFound(string message) : base(message)
    {

    }
}