namespace Ted.Shared.Application;

/// <summary>
/// Contract for retrieving the current date & time.
/// </summary>
/// <remarks>
/// Useful for injecting specific values for tests.
/// </remarks>
public interface IDateTimeOffset
{
    /// <summary>
    /// Gets a <see cref="DateTimeOffset" /> object that is set to the current date and time on the current computer,
    /// with the offset set to the local time's offset from Coordinated Universal Time (UTC).
    /// </summary>
    DateTimeOffset Now { get; }

    /// <summary>
    /// Gets a <see cref="DateTimeOffset" /> object whose date and time are set to the current Coordinated Universal
    /// Time (UTC) date and time and whose offset is <see cref="TimeSpan.Zero">Zero</see>.
    /// </summary>
    DateTimeOffset UtcNow { get; }
}