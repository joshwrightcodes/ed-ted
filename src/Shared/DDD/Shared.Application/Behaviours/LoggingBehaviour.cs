using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
// ReSharper disable ContextualLoggerProblem

namespace Ted.Shared.Application.Behaviours;

/// <summary>
/// MediatR preprocessor step that automatically logs all requests coming through the MediatR pipeline.
/// </summary>
/// <typeparam name="TRequest"></typeparam>
public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    where TRequest : notnull
{
    private readonly ICurrentUserService _currentUserService;
    private readonly ILogger _logger;

    /// <summary>
    /// Initialises a new instance of the see <see cref="LoggingBehaviour{TRequest}"/> object.
    /// </summary>
    /// <param name="logger">Request logger instance.</param>
    /// <param name="currentUserService">Current User Service instance.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when either <paramref name="logger"/> or <paramref name="currentUserService"/> are <c>null</c>.
    /// </exception>
    public LoggingBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
    }

    /// <inheritdoc />
    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var userId = _currentUserService.UserId;

        _logger.LogInformation("Request: {Name} {@UserId} {@Request}",
            requestName, userId, request);

        return Task.CompletedTask;
    }
}