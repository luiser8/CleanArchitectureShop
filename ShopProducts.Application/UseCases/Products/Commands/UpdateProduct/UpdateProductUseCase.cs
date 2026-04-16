using ShopProducts.Application.Contracts;
using ShopProducts.Application.Utils.Mediator;
using ShopProducts.Domain.Exceptions;

namespace ShopProducts.Application.UseCases.Products.Commands.UpdateProduct
{
    public class UpdateProductUseCase(IProductRepository repository) : IRequestHandler<UpdateProductCommand>
    {
        public async Task Handle(UpdateProductCommand request)
        {
            var product = await repository.GetById(request.Id);
            if (product is null)
            {
                throw new ExceptionNotFound("Product not found");
            }

            product.Update(request.Name, request.Description, request.Price, request.Amount, request.Active);
           await repository.Update(product);
        }
    }
}
