using Application.Data;
using Domain.Exceptions.Cart;

namespace Contract.Service.Cart
{
    public static class CartUtils
    {
        public static async Task<Domain.Entities.Cart> FindCart(Guid Cart_id, IUnitOfWork _unitOfWork)
        {
            var Cart = await _unitOfWork.GetRepository<Domain.Entities.Cart, Guid>()
                .FindByIdAsync(Cart_id);
            if (Cart == null) throw new CartNotFound(Cart_id);
            return Cart;
        }
        public static async Task<Domain.Entities.CartProduct> FindCartProduct(Guid Cart_id, Guid Product_id, IUnitOfWork _unitOfWork)
        {
            var CartProduct = await _unitOfWork.GetRepository<Domain.Entities.CartProduct, Guid>()
                .FindSingleAsync(x => x.Cart_id == Cart_id && x.Product_id == Product_id);
            if (CartProduct == null) throw new CartNotFound(Cart_id);
            return CartProduct;
        }
    }
}
