namespace CinemaBooking.Common.Abstractions.Entities;

/// <summary>
/// Base class to represent an entity in the system.
/// </summary>
public abstract class Entity
{
    public Guid Id { get; protected set; }
}