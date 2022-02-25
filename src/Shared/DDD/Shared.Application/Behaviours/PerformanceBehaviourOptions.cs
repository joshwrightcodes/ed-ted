namespace Ted.Shared.Application.Behaviours;

/// <summary>
/// Options for <see cref="PerformanceBehaviour{TRequest,TResponse}"/>.
/// </summary>
public class PerformanceBehaviourOptions
{
    /// <summary>
    /// Gets or sets the threshold for when the <see cref="PerformanceBehaviour{TRequest,TResponse}">performance behaviour
    /// handler</see> should log the request.
    /// </summary>
    public TimeSpan Threshold { get; set; } = TimeSpan.FromMilliseconds(500);
}