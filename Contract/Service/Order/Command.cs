using Contract.Abstraction.Message;
using Contract.DTOs.OrderDTO;

namespace Contract.Service.Order
{
    public static class Command
    {
        public record CreateOrder(CreateOrderDTO CreateOrderDTO) : ICommand<BaseResponse> { }
        public record UpdateOrderStatus(Guid Order_id, OrderStatus OrderStatus) : ICommand<BaseResponse> { }
        public record SetNewOrderStatus(InputOrderStatus OrderStatus) : ICommand<BaseResponse> { }
    }
}
