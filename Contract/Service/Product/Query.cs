using Contract.Abstraction.Message;

namespace Contract.Service.Product
{
    public static class Query
    {
        public record FindProductById(Guid Product_id) : IQuery<Response>;
        public record GetProducts() : IQuery<ICollection<Response>> { }
    }
}
