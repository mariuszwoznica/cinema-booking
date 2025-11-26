namespace CinemaBooking.Common.Abstractions.Queries;

/// <summary>
/// Defines a handler for a query.
/// </summary>
/// <typeparam name="TQuery">The type of query</typeparam>
/// <typeparam name="TResponse">The type of result from the handler</typeparam>
public interface IQueryHandler<in TQuery, TResponse> 
    where TQuery : class, IQuery<TResponse>
{
    /// <summary>
    /// Handles a query.
    /// </summary>
    /// <param name="query">The query</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Result form the query</returns>
    Task<TResponse> HandleAsync(TQuery query, CancellationToken cancellationToken);
}