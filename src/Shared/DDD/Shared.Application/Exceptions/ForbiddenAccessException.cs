using System.Runtime.Serialization;

namespace Ted.Shared.Application.Exceptions;

/// <summary>
/// Represents an error that occurs when a user attempts to access a resource they do not have permission to access.
/// </summary>
[Serializable]
public class ForbiddenAccessException : Exception
{
    /// <summary>
    /// Initialises a new instance of the <see cref="ForbiddenAccessException" /> class.
    /// </summary>
    public ForbiddenAccessException()
    {
    }

    /// <summary>
    /// Initialises a new instance of the <see cref="ForbiddenAccessException" /> class with serialized data.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected ForbiddenAccessException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    /// <summary>
    /// Initialises a new instance of the <see cref="ForbiddenAccessException" /> class with a specified error message.
    /// </summary>
    /// <param name="message">
    /// The error message that explains the reason for the exception.
    /// </param>
    public ForbiddenAccessException(string? message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ForbiddenAccessException" /> class with a specified error message
    /// and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">
    /// The error message that explains the reason for the exception.
    /// </param>
    /// <param name="innerException">
    /// The exception that is the cause of the current exception, or a null reference if no inner exception is
    /// specified.
    /// </param>
    public ForbiddenAccessException(string? message, Exception innerException)
        : base(message, innerException)
    {
    }
}