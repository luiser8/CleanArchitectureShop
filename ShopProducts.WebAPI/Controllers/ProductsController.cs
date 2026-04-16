using Microsoft.AspNetCore.Mvc;
using ShopProducts.Application.UseCases.Products.Commands.AdjustmentInventoryUseCase;
using ShopProducts.Application.UseCases.Products.Commands.CreateProduct;
using ShopProducts.Application.UseCases.Products.Commands.DeleteProduct;
using ShopProducts.Application.UseCases.Products.Commands.UpdateProduct;
using ShopProducts.Application.UseCases.Products.Querys.FilterProducts;
using ShopProducts.Application.UseCases.Products.Querys.QueryProduct;
using ShopProducts.Application.Utils.Mediator;
using ShopProducts.WebAPI.DTos;

namespace ShopProducts.WebAPI.Controllers
{
    [Route("api/products")]
    public class ProductsController(IMediator mediator) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetailDto>> GetById(Guid id)
        {
            var query = new GetByIdProductQuery(id);
            var product = await mediator.Send(query);
            if (product is null)
                return NotFound();
            return Ok(product);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<FilterProductsDto>>> GetByFilter([FromQuery] string? name, [FromQuery] bool? active)
        {
            var query = new FilterProductsQuery(name, active);
            var products = await mediator.Send(query);
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProductDto model)
        {
            var command = new CreateProductCommand(
                Name: model.Name,
                Description: model.Description,
                Price: model.Price,
                Amount: model.Amount,
                QuantityInventory: model.InventoryInitial
            );

            var id = await mediator.Send(command);
            return CreatedAtAction(nameof(Create), new { id }, null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateProductDto model)
        {
            var command = new UpdateProductCommand(
                Id: id,
                Name: model.Name,
                Description: model.Description,
                Price: model.Price,
                Amount: model.Amount,
                Active: model.Active
            );

            await mediator.Send(command);
            return NoContent();
        }

        [HttpPost("{id}/inventory")]
        public async Task<ActionResult> AdjustInventory(Guid id, [FromBody] AdjustmentInventoryDto model)
        {
            var command = new AdjustmentInventoryCommand(
                Id: id,
                Delta: model.Delta
            );

            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var request = new DeleteProductCommand(id);
            await mediator.Send(request);
            return NoContent();
        }
    }
}
