using AutoMapper;
using Application.Abstractions;
using Contract.Abstraction.Message;
using Contract.Abstraction.Shared;
using Contract.Enumerations;
using Contract.Service;
using Domain.Exceptions.Common;
using Domain.Exceptions.Product;
using static Contract.Service.Order.Command;
using Application.Data;

namespace DistributedSystem.Application.Features.V1.Command.Order
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrder, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) =>
            (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public async Task<Result<BaseResponse>> Handle(CreateOrder request, CancellationToken cancellationToken)
        {
            decimal total = 0;
            Dictionary<Guid, Domain.Entities.Product> productDictionary = new Dictionary<Guid, Domain.Entities.Product>();
            foreach (var item in request.CreateOrderDTO.InputOrderProducts)
            {
                var product = await _unitOfWork.GetRepository<Domain.Entities.Product, Guid>()
                    .FindByIdAsync(item.Product_id);
                if (product.Quantity < item.TotalProduct) throw new ProductBadRequest(item.Product_id);
                product.Quantity -= item.TotalProduct;
                productDictionary.Add(item.Product_id, product);
                total += item.TotalProduct * product.Price;
            }
            var order = _mapper.Map<Domain.Entities.Order>(request.CreateOrderDTO);
            //Total for order
            order.TotalOrder = total;
            _unitOfWork.GetRepository<Domain.Entities.Order, Guid>().Add(order);
            var affectedRecord = await _unitOfWork.SaveChangesAsync();
            if (affectedRecord < 1) throw new InternalServerError();
            
            foreach (var item in request.CreateOrderDTO.InputOrderProducts)
            {
                if (!productDictionary.ContainsKey(item.Product_id)) continue;
                Domain.Entities.Product product = productDictionary[item.Product_id];
                _unitOfWork.GetRepository<Domain.Entities.Product, Guid>().Update(product);
                _unitOfWork.GetRepository<Domain.Entities.OrderProducts, Guid>()
                    .Add(new Domain.Entities.OrderProducts
                    {
                        Order_id = order.Id,
                        Product_id = item.Product_id,
                        TotalProduct = item.TotalProduct,
                    });
            }
            _unitOfWork.GetRepository<Domain.Entities.OrderShipping, Guid>()
                    .Add(new Domain.Entities.OrderShipping
                    {
                        Order_id = order.Id,
                        Province = request.CreateOrderDTO.InputOrderShipping.Province,
                        District = request.CreateOrderDTO.InputOrderShipping.District,
                        Address = request.CreateOrderDTO.InputOrderShipping.Address,
                    });
            _unitOfWork.GetRepository<Domain.Entities.OrderStatus, Guid>()
                    .Add(new Domain.Entities.OrderStatus
                    {
                        Order_id = order.Id,
                        Name = OrderStatusType.PENDING,
                        Note = "Waiting for ShopShop Checking!",
                        Date = DateTime.Now.ToString(),
                    });
            await _unitOfWork.SaveChangesAsync();
            return new BaseResponse
            {
                Success = true,
                Errors = [],
                Message = "Create Order Successfully!"
            };
        }
    }
}
