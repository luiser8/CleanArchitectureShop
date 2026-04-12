using ShopProducts.Domain.Entities;

namespace ShopProducts.Application.Contracts;

public interface IProductRepository
{
    Task Add(Product product);
    Task<bool> Exists(string name);
}