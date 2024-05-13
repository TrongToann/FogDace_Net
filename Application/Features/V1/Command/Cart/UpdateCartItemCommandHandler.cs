using Application.Data;
using AutoMapper;
using Contract.Abstraction.Message;
using Contract.Abstraction.Shared;
using Contract.Service.Cart;
using Domain.Exceptions.Cart;
using Microsoft.EntityFrameworkCore;
using static Contract.Service.Cart.Command;

namespace Application.Features.V1.Command.Cart
{
    public class UpdateCartItemCommandHandler : ICommandHandler<UpdateCartItem, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCartItemCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) =>
            (_unitOfWork, _mapper) = (unitOfWork, mapper);
        public async Task<Result<Response>> Handle(UpdateCartItem request, CancellationToken cancellationToken)
        {
            var Cart = await _unitOfWork.GetRepository<Domain.Entities.Cart, Guid>()
                .FindByIdAsync(request.Cart_id);
            if (Cart == null) throw new CartNotFound(request.Cart_id);
            var CartProduct = await _unitOfWork.GetRepository<Domain.Entities.CartProduct, Guid>()
                 .FindSingleAsync(x => x.Cart_id == request.Cart_id && x.Product_id == request.UpdateCartItemDTO.Product_id);
            if (CartProduct == null) throw new CartNotFound(request.Cart_id);
            CartProduct.Total = request.UpdateCartItemDTO.Type.ToLower().Equals("increase")
                ? CartProduct.Total += request.UpdateCartItemDTO.Quantity
                : CartProduct.Total -= request.UpdateCartItemDTO.Quantity;
            Cart.Count_Product = request.UpdateCartItemDTO.Type.ToLower().Equals("increase")
                ? Cart.Count_Product += request.UpdateCartItemDTO.Quantity
                : Cart.Count_Product -= request.UpdateCartItemDTO.Quantity;
            _unitOfWork.GetRepository<Domain.Entities.Cart, Guid>().Update(Cart);
            _unitOfWork.GetRepository<Domain.Entities.CartProduct, Guid>().Update(CartProduct);
            await _unitOfWork.SaveChangesAsync();
            var CartProducts = await _unitOfWork.GetRepository<Domain.Entities.CartProduct, Guid>()
                 .GetAll(x => x.Cart_id == request.Cart_id, includeProperties: x => x.Product)
                 .ToListAsync();
            Cart.CartProducts = CartProducts;
            
            return _mapper.Map<Response>(Cart);
        }
    }
}
