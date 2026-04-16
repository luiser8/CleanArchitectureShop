using Microsoft.Extensions.DependencyInjection;
using ShopProducts.Application.UseCases.Products.Commands.AdjustmentInventoryUseCase;
using ShopProducts.Application.UseCases.Products.Commands.CreateProduct;
using ShopProducts.Application.UseCases.Products.Commands.DeleteProduct;
using ShopProducts.Application.UseCases.Products.Commands.UpdateProduct;
using ShopProducts.Application.UseCases.Products.Querys.FilterProducts;
using ShopProducts.Application.UseCases.Products.Querys.QueryProduct;
using ShopProducts.Application.Utils.Mediator;

namespace ShopProducts.Application;

public static class DependencyInjection
{
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IMediator, SimpleMediator>();
            services.AddScoped<IRequestHandler<CreateProductCommand, Guid>, CreateProductUseCase>();
            services.AddScoped<IRequestHandler<UpdateProductCommand>, UpdateProductUseCase>();
            services.AddScoped<IRequestHandler<AdjustmentInventoryCommand>, AdjustmentInventoryUseCase>();
            services.AddScoped<IRequestHandler<GetByIdProductQuery, ProductDetailDto>, GetByIdProductUseCase>();
            services.AddScoped<IRequestHandler<FilterProductsQuery, List<FilterProductsDto>>, FilterProductsUseCase>();
            services.AddScoped<IRequestHandler<DeleteProductCommand>, DeleteProductUseCase>();

        return services;
    }
}
