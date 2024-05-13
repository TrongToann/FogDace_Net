namespace Contract.DTOs.OrderDTO
{
    public class InputOrderStatus
    {
        public Guid Order_id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public string Date { get; set; }
    }
}
