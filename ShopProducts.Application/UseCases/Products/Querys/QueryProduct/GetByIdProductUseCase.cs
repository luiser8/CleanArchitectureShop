using ShopProducts.Application.Contracts;
using ShopProducts.Application.Utils.Mediator;
using ShopProducts.Domain.Exceptions;

namespace ShopProducts.Application.UseCases.Products.Querys.QueryProduct;

public class GetByIdProductUseCase(IProductRepository productRepository) : IRequestHandler<GetByIdProductQuery, ProductDetailDto>
{
    public async Task<ProductDetailDto> Handle(GetByIdProductQuery request)
    {
       var product = await productRepository.GetById(request.Id);
       if (product == null)
       {
           throw new ExceptionNotFound("Product not found");
       }

       return product.ToProductDetailDto();
    }
}
