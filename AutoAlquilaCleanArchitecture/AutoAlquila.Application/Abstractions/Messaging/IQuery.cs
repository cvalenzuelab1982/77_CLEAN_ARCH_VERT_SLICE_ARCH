using AutoAlquila.Domain.Abstractions;
using MediatR;

namespace AutoAlquila.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
