namespace Ted.Shared.Application;

/// <summary>
/// Contract for obtaining the current authenticated user.
/// </summary>
public interface ICurrentUserService
{
    /// <summary>
    /// Gets the user id of the currently authenticated user.
    /// </summary>
    string? UserId { get; }
}