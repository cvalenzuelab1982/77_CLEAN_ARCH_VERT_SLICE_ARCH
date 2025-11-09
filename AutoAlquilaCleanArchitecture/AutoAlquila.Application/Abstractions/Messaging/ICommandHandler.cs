using AutoAlquila.Domain.Abstractions;
using MediatR;

namespace AutoAlquila.Application.Abstractions.Messaging
{
    public interface ICommandHandler<TCommnand> : IRequestHandler<TCommnand, Result> where TCommnand : ICommand
    {

    }

    public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>> where TCommand : ICommand<TResponse>
    {

    }
}
