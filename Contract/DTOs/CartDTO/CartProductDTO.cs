namespace Contract.DTOs.CartDTO
{
    public class CartProductDTO
    {
        public Guid Product_id { get; set; }
        public ProductDTO.ProductDTO Product { get; set; }
        public int Total { get; set; }
    }
}
