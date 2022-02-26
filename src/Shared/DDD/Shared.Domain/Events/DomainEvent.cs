namespace Ted.Shared.Domain.Events;

/// <summary>
/// Base class for defining Domain Events within the application.
/// </summary>
public abstract class DomainEvent
{
    /// <summary>
    /// Creates a new instance of the <see cref="DomainEvent" /> class, initialising <see cref="OccurredOn" /> to
    /// <see cref="DateTimeOffset.UtcNow" />.
    /// </summary>
    protected DomainEvent()
    {
        OccurredOn = DateTimeOffset.UtcNow;
    }

    /// <summary>
    /// Gets or sets a value indicating whether a <see cref="DomainEvent">domain event</see> has been published or not.
    /// </summary>
    /// <value>
    /// Value is <c>true</c> when the event has been published by the application, otherwise the value is <c>false</c>.
    /// </value>
    public bool IsPublished { get; set; }

    /// <summary>
    /// Gets when the <see cref="DomainEvent">domain event</see> was raised by the application.
    /// </summary>
    public DateTimeOffset OccurredOn { get; protected set; }
}