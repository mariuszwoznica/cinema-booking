namespace CinemaBooking.Common.Abstractions.Queries;

/// <summary>
/// Marker interface to represent a query in the system.
/// </summary>
/// <typeparam name="TResponse">The type of result from the query</typeparam>
public interface IQuery<TResponse>;