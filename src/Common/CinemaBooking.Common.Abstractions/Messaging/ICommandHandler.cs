namespace CinemaBooking.Common.Abstractions.Messaging;

/// <summary>
/// Defines a handler for a command.
/// </summary>
/// <typeparam name="TCommand">The type of command</typeparam>
public interface ICommandHandler<in TCommand> 
    where TCommand : class, ICommand
{
    /// <summary>
    /// Handles a command.
    /// </summary>
    /// <param name="command">The command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    Task HandleAsync(TCommand command, CancellationToken cancellationToken);
}