namespace CinemaBooking.Common.Abstractions.Messaging;

/// <summary>
/// Dispatcher delivers commands and queries to the appropriate handler.
/// </summary>
public interface IDispatcher
{
    Task SendAsync(ICommand command, CancellationToken cancellationToken = default);
    Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default);
}