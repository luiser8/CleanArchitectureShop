using Microsoft.EntityFrameworkCore;
using ShopProducts.Application.Contracts;
using ShopProducts.Domain.Entities;

namespace ShopProducts.Infrastructure.Persistence.Repositories;

public class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    public async Task Add(Product product, CancellationToken cancellationToken = default)
    {
        await context.Products.AddAsync(product, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken = default)
    {
        await context.Products
            .Where(p => p.Id == id)
            .ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<bool> Exists(string name, CancellationToken cancellationToken = default)
    {
        return await context.Products
            .AsNoTracking()
            .AnyAsync(p => p.Name == name, cancellationToken);
    }

    public async Task<List<Product>> GetByFilter(string? Name, bool? Active)
    {
        var query = context.Products.AsQueryable();

        if (!string.IsNullOrEmpty(Name) || Name is not null)
        {
            query = query.Where(p => p.Name.Contains(Name));
        }

        if (Active.HasValue || Active is not null)
        {
            query = query.Where(p => p.Active == Active);
        }

        return await query.ToListAsync();
    }

    public async Task<Product?> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task Update(Product product, CancellationToken cancellationToken = default)
    {
        context.Products.Update(product);
        await context.SaveChangesAsync(cancellationToken);
    }
}