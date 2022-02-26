namespace Ted.Shared.Application.Behaviours;

/// <summary>
/// Options for <see cref="PerformanceBehaviour{TRequest,TResponse}"/>.
/// </summary>
public class PerformanceBehaviourOptions
{
    /// <summary>
    /// Initialises a new instance of the <see cref="PerformanceBehaviourOptions"/> object with a default value of
    /// <c>500ms</c> for <see cref="Threshold"/>.
    /// </summary>
    public PerformanceBehaviourOptions()
    {
        Threshold = TimeSpan.FromMilliseconds(500);
    }

    /// <summary>
    /// Gets or sets the threshold for when the <see cref="PerformanceBehaviour{TRequest,TResponse}">performance behaviour
    /// handler</see> should log the request.
    /// </summary>
    public TimeSpan Threshold { get; set; }
}