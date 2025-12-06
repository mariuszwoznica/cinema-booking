using CinemaBooking.Common.Abstractions.Queries;
using Microsoft.Extensions.Logging;

namespace CinemaBooking.Common.Infrastructure.Logging.Decorators;

internal sealed class LoggingQueryHandlerDecorator<TQuery, TResponse>(
    IQueryHandler<TQuery, TResponse> decorated, 
    ILogger<LoggingQueryHandlerDecorator<TQuery, TResponse>> logger) : IQueryHandler<TQuery, TResponse> 
        where TQuery : class, IQuery<TResponse>
{
    private readonly IQueryHandler<TQuery, TResponse> _decorated = decorated;
    private readonly ILogger<LoggingQueryHandlerDecorator<TQuery, TResponse>> _logger = logger
        ?? throw new ArgumentNullException(nameof(logger));
    
    public async Task<TResponse> HandleAsync(TQuery query, CancellationToken cancellationToken)
    {
        var queryTypeName = typeof(TQuery).Name;
        _logger.LogInformation("Handling a query {QueryTypeName}", queryTypeName);
        
        var result = await _decorated.HandleAsync(query, cancellationToken);
        
        _logger.LogInformation("Handled a query {QueryTypeName}", queryTypeName);
        
        return result;
    }
}