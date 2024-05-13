using Contract.Abstraction.Shared;
using MediatR;

namespace Contract.Abstraction.Message
{
    public interface IQuery<TRespone> : IRequest<Result<TRespone>> { }
}
