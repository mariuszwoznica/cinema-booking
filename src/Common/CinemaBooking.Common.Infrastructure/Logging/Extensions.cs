using CinemaBooking.Common.Abstractions.Commands;
using CinemaBooking.Common.Abstractions.Queries;
using CinemaBooking.Common.Infrastructure.Logging.Decorators;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace CinemaBooking.Common.Infrastructure.Logging;

public static class Extensions
{
    public static IServiceCollection AddLoggingDecorators(this IServiceCollection services)
    {
        services.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));
        services.TryDecorate(typeof(IQueryHandler<,>), typeof(LoggingQueryHandlerDecorator<,>));
        
        return services;
    }

    public static IHostBuilder UseLogging(this IHostBuilder builder)
        => builder.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration));
}