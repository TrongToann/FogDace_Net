namespace Contract.DTOs.OrderDTO
{
    public class OrderProduct
    {
        public Guid Product_id { get; set; }
        public ProductDTO.ProductDTO Product { get; set; }
        public int TotalProduct { get; set; }
    }
}
