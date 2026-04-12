using Microsoft.EntityFrameworkCore;
using ShopProducts.Application.Contracts;
using ShopProducts.Domain.Entities;

namespace ShopProducts.Infrastructure.Persistence.Repositories;

public class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    public async Task Add(Product product)
    {
        context.Products.Add(product);
        await context.SaveChangesAsync();
    }

    public async Task<bool> Exists(string name)
    {
        return await context.Products.AnyAsync(p => p.Name == name);
    }
}