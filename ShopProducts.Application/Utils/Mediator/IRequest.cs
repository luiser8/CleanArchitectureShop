namespace ShopProducts.Application.Utils.Mediator;

public interface IRequest<TResponse>
{

}

public interface IRequest
{

}

public interface IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    Task<TResponse> Handle(TRequest request);
}

public interface IRequestHandler<TRequest>
{
    Task Handle(TRequest request);
}