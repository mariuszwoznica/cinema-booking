using CinemaBooking.Common.Abstractions.Commands;
using Microsoft.Extensions.Logging;

namespace CinemaBooking.Common.Infrastructure.Logging.Decorators;

internal sealed class LoggingCommandHandlerDecorator<TCommand>(
    ICommandHandler<TCommand> decorated, 
    ILogger<LoggingCommandHandlerDecorator<TCommand>> logger) : ICommandHandler<TCommand> 
        where TCommand : class, ICommand
{
    private readonly ICommandHandler<TCommand> _decorated = decorated;
    private readonly ILogger<LoggingCommandHandlerDecorator<TCommand>> _logger = logger 
        ?? throw new ArgumentNullException(nameof(logger));
    
    public async Task HandleAsync(TCommand command, CancellationToken cancellationToken)
    {
        var commandTypeName = typeof(TCommand).Name;
        _logger.LogInformation("Handling a command {CommandTypeName}", commandTypeName);
        
        await _decorated.HandleAsync(command, cancellationToken);
        
        _logger.LogInformation("Handled a command {CommandTypeName}", commandTypeName);
    }
}