using Contract.Abstraction.Message;
using Contract.Abstraction.Shared;
using Contract.Service.Order;
using Domain.Abstraction.Repositories;
using MediatR;
using static Contract.Service.Order.Query;

namespace Application.Features.V1.Queries.Order
{
    public class GetOrdersQueryHandler : IQueryHandler<GetOrders, ICollection<Response>>
    {
        private readonly IMediator _mediator;
        private readonly IOrderRepository _orderRepository;

        public GetOrdersQueryHandler(IOrderRepository orderRepository, IMediator mediator)
        {
            _orderRepository = orderRepository;
            _mediator = mediator;
        }

        public async Task<Result<ICollection<Response>>> Handle(GetOrders request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllAsync();
            return await GetAllOrderDetail(orders);
        }
        private async Task<List<Response>> GetAllOrderDetail(IEnumerable<Domain.Entities.Order> orders)
        {
            var orderResults = new List<Response>();
            foreach (var order in orders)
            {
                var command = new FindOrderById(order.Id);
                Result<Response> result = await _mediator.Send(command);
                orderResults.Add(result.Value);
            }
            return orderResults;
        }
    }
}
