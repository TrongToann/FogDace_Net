using Contract.Abstraction.Message;

namespace Contract.Service.Order
{
    public static class Query
    {
        public record FindOrderById(Guid Order_id) : IQuery<Response> { }
        public record GetOrders() : IQuery<ICollection<Response>> { }
    }
}
