
namespace Contract.DTOs.CartDTO
{
    public class AddToCartDTO : ICartDTO
    {
        public Guid Account_id { get; set; }
        public InputProductDTO InputProductDTO { get; set; }

    }
    public class InputProductDTO
    {
        public Guid Product_id { get; set; }
        public int Total { get; set; }
    }
}
