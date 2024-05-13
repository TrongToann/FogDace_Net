using Contract.Abstraction.Shared;
using MediatR;

namespace Contract.Abstraction.Message
{
    public interface ICommand : IRequest<Result> { }
    public interface ICommand<TRespone> : IRequest<Result<TRespone>> { }
}
