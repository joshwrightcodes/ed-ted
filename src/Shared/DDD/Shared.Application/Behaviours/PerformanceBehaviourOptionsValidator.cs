using FluentValidation;

namespace Ted.Shared.Application.Behaviours;

/// <summary>
/// Validator for <see cref="PerformanceBehaviourOptions"/>.
/// </summary>
public class PerformanceBehaviourOptionsValidator : AbstractValidator<PerformanceBehaviourOptions>
{
    /// <summary>
    /// Initialises a new instance of the <see cref="PerformanceBehaviourOptionsValidator"/> class.
    /// </summary>
    public PerformanceBehaviourOptionsValidator()
    {
        RuleFor(p => p.Threshold)
            .InclusiveBetween(TimeSpan.FromMilliseconds(200), TimeSpan.FromMinutes(1));
    }
}