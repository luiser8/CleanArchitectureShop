using ShopProducts.Application.Contracts;
using ShopProducts.Application.Utils.Mediator;
using ShopProducts.Domain.Entities;
using ShopProducts.Domain.Exceptions;
using ShopProducts.Domain.ValueObjects;

namespace ShopProducts.Application.UseCases.Products.Commands.CreateProduct;

public class CreateProductUseCase(IProductRepository repository) : IRequestHandler<CreateProductCommand, Guid>
{
    public async Task<Guid> Handle(CreateProductCommand command)
    {
        var exists = await repository.Exists(command.Name);
        if (exists) throw new ExceptionBusinessRule($"Product already exists {command.Name}");

        var quantityInventory = QuantityInventory.Create(command.QuantityInventory);
        var product = Product.Create(command.Name, command.Description, command.Price, command.Amount, quantityInventory);
        
        await repository.Add(product);
        return product.Id;
    }   
}