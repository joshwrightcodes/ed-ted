namespace Ted.Shared.Domain.Entities;

/// <summary>
/// Base class for entities that need to keep track of when entities where created/modified.
/// </summary>
public abstract class AuditableEntity
{
    /// <summary>
    /// Gets or sets when the entity was created in the application.
    /// </summary>
    public DateTimeOffset CreatedOn { get; set; }

    /// <summary>
    /// Gets or sets the id of the user who created the entity in the application.
    /// </summary>
    public string? CreatedBy { get; set; }

    /// <summary>
    /// Gets or sets when the entity was last modified by the application.
    /// </summary>
    public DateTimeOffset ModifiedOn { get; set; }

    /// <summary>
    /// Gets or sets the id of the user who created the entity in the application.
    /// </summary>
    public string? ModifiedBy { get; set; }
}