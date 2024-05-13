using Application.Data;
using AutoMapper;
using Contract.Abstraction.Message;
using Contract.Abstraction.Shared;
using Contract.Service;
using Domain.Exceptions.Account;
using Domain.Exceptions.Common;
using static Contract.Service.Cart.Command;

namespace Application.Features.V1.Command.Cart
{
    public class AddToCartCommandHandler : ICommandHandler<AddToCart, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddToCartCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) => 
              (_unitOfWork, _mapper) = (unitOfWork, mapper);
        public async Task<Result<BaseResponse>> Handle(AddToCart request, CancellationToken cancellationToken)
        {
            await CheckValidUser(request.addToCart.Account_id);
            var cartCheck = await CreateCartIfNotExist(request);
            InsertProduct(request, cartCheck);

            cartCheck.Count_Product += 1;
             _unitOfWork.GetRepository<Domain.Entities.Cart, Guid>().Update(cartCheck);
            var affected = await _unitOfWork.SaveChangesAsync();

            if (affected < 1) throw new InternalServerError();
            var response = new BaseResponse();
            response.Success = true;
            response.Message = "Add Successfully!";
            return response;
        }
        private async void InsertProduct(AddToCart request, Domain.Entities.Cart cart)
        {
            var attributeCheck = await _unitOfWork.GetRepository<Domain.Entities.CartProduct, Guid>()
                .FindSingleAsync(x => x.Product_id == request.addToCart.InputProductDTO.Product_id);

            if (attributeCheck != null)
            {
                attributeCheck.Total += request.addToCart.InputProductDTO.Total;
                _unitOfWork.GetRepository<Domain.Entities.CartProduct, Guid>().Update(attributeCheck);
                return;
            }
            var attribute = new Domain.Entities.CartProduct
              {
                 Cart_id = cart.Id,
                 Product_id = request.addToCart.InputProductDTO.Product_id,
                 Total = request.addToCart.InputProductDTO.Total,
              };
             _unitOfWork.GetRepository<Domain.Entities.CartProduct, Guid>().Add(attribute);
            return;
        }
        private async Task CheckValidUser(Guid User_id)
        {
            var userCheck = await _unitOfWork.GetRepository<Domain.Entities.Account, Guid>()
                .FindByIdAsync(User_id);
            if (userCheck == null) throw new UserNotFound(User_id);
            return;
        }
        private async Task<Domain.Entities.Cart> CreateCartIfNotExist(AddToCart request)
        {
            var cartCheck = await _unitOfWork.GetRepository<Domain.Entities.Cart, Guid>()
                .FindSingleAsync(x => x.Account_id == request.addToCart.Account_id);
            if (cartCheck == null)
            {
                var cart = _mapper.Map<Domain.Entities.Cart>(request.addToCart);
                cart.Count_Product = 0;
                _unitOfWork.GetRepository<Domain.Entities.Cart, Guid>().Add(cart);
                var affectedRecords = await _unitOfWork.SaveChangesAsync();
                if (affectedRecords < 1) throw new InternalServerError();
                cartCheck = cart;
            }
            return cartCheck;
        }
    }
    
}
