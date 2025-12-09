using CinemaBooking.Common.Abstractions.Commands;
using Microsoft.Extensions.Logging;

namespace CinemaBooking.Common.Infrastructure.Logging.Decorators;

internal sealed class LoggingCommandHandlerDecorator<TCommand>(
    ICommandHandler<TCommand> decorated, 
    ILogger<LoggingCommandHandlerDecorator<TCommand>> logger) : ICommandHandler<TCommand> 
        where TCommand : class, ICommand
{
    public async Task HandleAsync(TCommand command, CancellationToken cancellationToken)
    {
        var commandTypeName =  typeof(TCommand).Name;
        logger.LogInformation("Handling a command {CommandTypeName}", commandTypeName);
        
        await decorated.HandleAsync(command, cancellationToken);
        
        logger.LogInformation("Handled a command {CommandTypeName}", commandTypeName);
    }
}