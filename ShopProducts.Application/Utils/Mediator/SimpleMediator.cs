using Microsoft.Extensions.DependencyInjection;

namespace ShopProducts.Application.Utils.Mediator;

public class SimpleMediator(IServiceProvider sp) : IMediator
{
    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
    {
        var typeHandler = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
        var useCase = sp.GetRequiredService(typeHandler);
        var method = typeHandler.GetMethod("Handle")!;
        return await (Task<TResponse>)method.Invoke(useCase, new object[] { request })!;
    }

    public Task Send(IRequest request)
    {
       var typeHandler = typeof(IRequestHandler<>).MakeGenericType(request.GetType());
        var useCase = sp.GetRequiredService(typeHandler);
        var method = typeHandler.GetMethod("Handle")!;
        return (Task)method.Invoke(useCase, new object[] { request })!;
    }
}
