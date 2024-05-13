﻿using Application.Data;
using AutoMapper;
using Contract.Abstraction.Message;
using Contract.Abstraction.Shared;
using Contract.Service.Order;
using Microsoft.EntityFrameworkCore;
using static Contract.Service.Order.Query;

namespace Application.Features.V1.Queries.Order
{
    public class FindOrderByIdQueryHandler : IQueryHandler<FindOrderById, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FindOrderByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) =>
            (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public async Task<Result<Response>> Handle(FindOrderById request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.GetRepository<Domain.Entities.Order, Guid>()
                .FindByIdAsync(request.Order_id,
                    includeProperties: [x => x.OrderProducts, x => x.OrderShipping, x => x.OrderStatus]);
            order.OrderProducts = await _unitOfWork.GetRepository<Domain.Entities.OrderProducts, Guid>()
                .GetAll(x => x.Order_id == order.Id, includeProperties: x => x.Product).ToListAsync(cancellationToken: cancellationToken);
            order.OrderStatus = await _unitOfWork.GetRepository<Domain.Entities.OrderStatus, Guid>()
                .GetAll(x => x.Order_id == order.Id).ToListAsync(cancellationToken: cancellationToken);

            return _mapper.Map<Response>(order);
        }
    }
}
