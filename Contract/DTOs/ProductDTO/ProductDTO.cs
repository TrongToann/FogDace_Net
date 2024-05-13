using Contract.DTOs.BaseDTO;

namespace Contract.DTOs.ProductDTO
{
    public class ProductDTO : Base, IProductDTO
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int Rating { get; set; }
        public int Sold_Quantity { get; set; }
    }
}
