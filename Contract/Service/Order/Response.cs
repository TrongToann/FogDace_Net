using Contract.DTOs.AccountDTO;
using Contract.DTOs.OrderDTO;
using System.Collections.ObjectModel;

namespace Contract.Service.Order
{
    public class Response
    {
        public Guid User_id { get; set; }
        public AccountDTO Account { get; set; }
        public string Payment_Medthod { get; set; }
        public Collection<OrderProduct> OrderProducts { get; set; }
        public InputOrderShipping OrderShipping { get; set; }
        public Collection<OrderStatus> OrderStatus { get; set; }
    }
}
