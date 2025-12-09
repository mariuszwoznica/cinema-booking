using CinemaBooking.Common.Abstractions.Queries;
using Microsoft.Extensions.Logging;

namespace CinemaBooking.Common.Infrastructure.Logging.Decorators;

internal sealed class LoggingQueryHandlerDecorator<TQuery, TResponse>(
    IQueryHandler<TQuery, TResponse> decorated,
    ILogger<LoggingQueryHandlerDecorator<TQuery, TResponse>> logger) : IQueryHandler<TQuery, TResponse> 
        where TQuery : class, IQuery<TResponse>
{
    public async Task<TResponse> HandleAsync(TQuery query, CancellationToken cancellationToken)
    {
        var queryTypeName = typeof(TQuery).Name;
        logger.LogInformation("Handling a query {QueryTypeName}", queryTypeName);
        
        var result = await decorated.HandleAsync(query, cancellationToken);
        
        logger.LogInformation("Handled a query {QueryTypeName}", queryTypeName);
        
        return result;
    }
}