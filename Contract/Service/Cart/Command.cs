using Contract.Abstraction.Message;
using Contract.DTOs.CartDTO;

namespace Contract.Service.Cart
{
    public static class Command
    {
        public record AddToCart(AddToCartDTO addToCart) : ICommand<BaseResponse>;
        public record UpdateCartItem(Guid Cart_id, UpdateCartItemDTO UpdateCartItemDTO) 
            : ICommand<Response>;

    }
}
