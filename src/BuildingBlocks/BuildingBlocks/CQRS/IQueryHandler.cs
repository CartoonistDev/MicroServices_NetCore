using MediatR;

namespace BuildingBlocks.CQRS;
// This helps to query/get request from our DB
public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
    where TResponse : notnull
{
}
