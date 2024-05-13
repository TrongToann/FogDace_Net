﻿using Contract.Abstraction.Shared;
using MediatR;

namespace Contract.Abstraction.Message
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
        where TCommand : ICommand
    { }
    public interface ICommandHandler<TCommand, TRespone> : IRequestHandler<TCommand, Result<TRespone>>
        where TCommand : ICommand<TRespone>
    { } 
}
