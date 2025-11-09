using AutoAlquila.Domain.Abstractions;
using MediatR;

namespace AutoAlquila.Application.Abstractions.Messaging
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse>
    {
    }
}
