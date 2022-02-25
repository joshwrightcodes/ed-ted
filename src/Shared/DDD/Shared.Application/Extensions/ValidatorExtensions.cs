
// ReSharper disable PossibleMultipleEnumeration

using FluentValidation;

namespace Ted.Shared.Application.Extensions;

/// <summary>
/// Extension methods for <see cref="IValidator"/>.
/// </summary>
public static class ValidatorExtensions
{
    /// <summary>
    /// Validates instance using specified validators. If no validators are supplied the method will automatically
    /// return.
    /// </summary>
    /// <param name="validators">Collection of validators to use.</param>
    /// <param name="instance">Instance of <typeparam name="T"> to validate.</typeparam></param>
    /// <param name="cancellationToken">Cancellation token, defaults to <see cref="CancellationToken.None"/>.</param>
    /// <typeparam name="T">Type of object to validate.</typeparam>
    /// <exception cref="ValidationException">
    /// Thrown when any of the validators encounter a validation failure.
    /// </exception>
    public static async Task ValidateAndThrow<T>(
        this IEnumerable<IValidator<T>> validators,
        T instance,
        CancellationToken cancellationToken = default)
    {
        if (validators.Any())
        {
            var context = new ValidationContext<T>(instance);

            var validationResults = await Task
                .WhenAll(
                validators.Select(v =>
                    v.ValidateAsync(context, cancellationToken)));

            var failures = validationResults
                .Where(r => r.Errors.Any())
                .SelectMany(r => r.Errors)
                .ToList();

            if (failures.Count > 0)
                throw new ValidationException(failures);
        }
    }
}