using ShopProducts.Domain.Entities;

namespace ShopProducts.Application.Contracts;

public interface IProductRepository
{
    Task Add(Product product, CancellationToken cancellationToken = default);
    Task<bool> Exists(string name, CancellationToken cancellationToken = default);
    Task<Product?> GetById(Guid id, CancellationToken cancellationToken = default);
    Task Update(Product product, CancellationToken cancellationToken = default);
    Task<List<Product>> GetByFilter(string? Name, bool? Active);
    Task Delete(Guid id, CancellationToken cancellationToken = default);
}