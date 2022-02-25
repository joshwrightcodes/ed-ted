namespace Ted.Shared.Domain.Events;

/// <summary>
/// Defines a contract for entities that have domain events.
/// </summary>
public interface IHasDomainEvents
{
    /// <summary>
    /// Gets or sets a collection of <see cref="DomainEvent">domain event</see> for the given entity.
    /// </summary>
    public List<DomainEvent> DomainEvents { get; set; }
}