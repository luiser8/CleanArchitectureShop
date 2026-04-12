using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopProducts.Application.Contracts;
using ShopProducts.Infrastructure.Persistence;
using ShopProducts.Infrastructure.Persistence.Repositories;

namespace ShopProducts.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer("name=DefaultConnection"));
        
        services.AddScoped<IProductRepository, ProductRepository>();
        
        return services;
    }
}