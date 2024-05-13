using Application.Data;
using AutoMapper;
using Contract.Abstraction.Message;
using Contract.Abstraction.Shared;
using Contract.Service;
using static Contract.Service.Order.Command;

namespace Application.Features.V1.Command.Order
{
    public class SetNewOrderStatusCommandHandler : ICommandHandler<SetNewOrderStatus, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SetNewOrderStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) =>
            (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public async Task<Result<BaseResponse>> Handle(SetNewOrderStatus request, CancellationToken cancellationToken)
        {
            var orderStatus = _mapper.Map<Domain.Entities.OrderStatus>(request.OrderStatus);
            _unitOfWork.GetRepository<Domain.Entities.OrderStatus, Guid>()
                .Add(orderStatus);
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
