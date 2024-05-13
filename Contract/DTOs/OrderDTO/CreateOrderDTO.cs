namespace Contract.DTOs.OrderDTO
{
    public class CreateOrderDTO : IOrderDTO
    {
        public Guid Account_id { get; set; }
        public string Payment_Medthod { get; set; }
        public List<InputOrderProduct> InputOrderProducts { get; set; }
        public InputOrderShipping InputOrderShipping { get; set; }
    }
}
