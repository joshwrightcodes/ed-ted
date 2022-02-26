using System.Diagnostics;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ted.Shared.Application.Extensions;

// ReSharper disable ContextualLoggerProblem

namespace Ted.Shared.Application.Behaviours;

/// <summary>
/// MediatR behaviour that records the performance of each request within the pipeline and logs any requests that
/// exceed a specified threshold.
/// </summary>
/// <typeparam name="TRequest">MediatR Request Type.</typeparam>
/// <typeparam name="TResponse">MediatR Response Type.</typeparam>
public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ICurrentUserService _currentUserService;
    private readonly ILogger<TRequest> _logger;
    private readonly Stopwatch _timer;

    /// <summary>
    /// Initialises a new instance of the <see cref="PerformanceBehaviour{TRequest,TResponse}"/> object.
    /// </summary>
    /// <param name="logger">Request logger instance.</param>
    /// <param name="currentUserService">Current user service instance.</param>
    /// <param name="options">Options for <see cref="PerformanceBehaviour{TRequest,TResponse}"/>.</param>
    /// <param name="validators">Validator for options specified in <paramref name="options"/>.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="logger"/>; <paramref name="currentUserService"/>;
    /// or <paramref name="options"/> are <c>null</c>.
    /// </exception>
    /// <exception cref="ValidationException">
    /// Thrown when any of the options specified in <paramref name="options"/> are invalid. Refer to
    /// <see cref="ValidationException.Errors"/> for specific validation failures.
    /// </exception>
    public PerformanceBehaviour(
        ILogger<TRequest> logger,
        ICurrentUserService currentUserService,
        IOptions<PerformanceBehaviourOptions> options,
        IEnumerable<IValidator<PerformanceBehaviourOptions>> validators)
    {
        _timer = new();

        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));

        ArgumentNullException.ThrowIfNull(options);

        validators.ValidateAndThrow(options.Value).GetAwaiter().GetResult();
    }

    /// <inheritdoc />
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        _timer.Start();

        var response = await next();

        _timer.Stop();

        var elapsedMilliseconds = _timer.ElapsedMilliseconds;

        if (elapsedMilliseconds <= 500) return response;

        var requestName = typeof(TRequest).Name;
        var userId = _currentUserService.UserId;

        _logger.LogWarning("Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@Request}",
            requestName, elapsedMilliseconds, userId, request);

        return response;
    }
}