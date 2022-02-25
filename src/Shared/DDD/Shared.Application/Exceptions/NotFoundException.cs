using System.Runtime.Serialization;

namespace Ted.Shared.Application.Exceptions;

[Serializable]
public class NotFoundException : Exception
{
    /// <summary>
    /// Initialises a new instance of the <see cref="ForbiddenAccessException" /> class.
    /// </summary>
    public NotFoundException()
    {
    }

    /// <summary>
    /// Initialises a new instance of the <see cref="NotFoundException" /> class with a specified error message.
    /// </summary>
    /// <param name="message">
    /// The error message that explains the reason for the exception.
    /// </param>
    public NotFoundException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException" /> class with a specified error message
    /// and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">
    /// The error message that explains the reason for the exception.
    /// </param>
    /// <param name="innerException">
    /// The exception that is the cause of the current exception, or a null reference if no inner exception is
    /// specified.
    /// </param>
    public NotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException" /> class for a specified entity type with
    /// a given identifier for the entity with a default message of <c>Entity "{name}" ({key}) was not found.</c>.
    /// </summary>
    /// <param name="name">
    /// Name of entity that could not be located.
    /// </param>
    /// <param name="key">
    /// Identifier of entity.
    /// specified.
    /// </param>
    public NotFoundException(string name, object key)
        : base($"Entity \"{name}\" ({key}) was not found.")
    {
    }

    /// <summary>
    /// Initialises a new instance of the <see cref="NotFoundException" /> class with serialized data.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected NotFoundException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}