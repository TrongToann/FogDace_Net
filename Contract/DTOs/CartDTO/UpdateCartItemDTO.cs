namespace Contract.DTOs.CartDTO
{
    public class UpdateCartItemDTO
    {
        public Guid Product_id { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
    }
}
