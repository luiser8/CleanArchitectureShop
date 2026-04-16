namespace ShopProducts.WebAPI.DTos
{
    public class UpdateProductDto : CreateProductDto
    {
        public bool Active { get; set; }
    }
}
