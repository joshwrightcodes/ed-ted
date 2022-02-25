using FluentValidation.Results;

namespace Ted.Shared.Application.Exceptions;

public class ValidationException : Exception
{
    /// <summary>
    /// Initialises a new instance of the <see cref="ValidationException" /> class with a default message.
    /// </summary>
    public ValidationException()
        : base("One or more validation failures have occurred.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    /// <summary>
    /// Initialises a new instance of the <see cref="ValidationException" /> class with a default message and the
    /// specified errors.
    /// </summary>
    public ValidationException(IEnumerable<ValidationFailure> failures)
        : this()
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }

    /// <summary>
    /// Initialises a new instance of the <see cref="ValidationException" /> class with a specified error message.
    /// </summary>
    /// <param name="message">
    /// The error message that explains the reason for the exception.
    /// </param>
    public ValidationException(string? message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationException" /> class with a specified error message
    /// and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">
    /// The error message that explains the reason for the exception.
    /// </param>
    /// <param name="innerException">
    /// The exception that is the cause of the current exception, or a null reference if no inner exception is
    /// specified.
    /// </param>
    public ValidationException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Gets a collection of validation errors for a property.
    /// </summary>
    /// <value>
    /// The key contains the property name, and the value contains one or more error messages for
    /// the given property.
    /// </value>
    public IDictionary<string, string[]> Errors { get; } = new Dictionary<string, string[]>();
}