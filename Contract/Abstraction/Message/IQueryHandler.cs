using Contract.Abstraction.Shared;
using MediatR;

namespace Contract.Abstraction.Message
{
    public interface IQueryHandler<TQuery, TResponse>
        : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>
    {
    }
}
