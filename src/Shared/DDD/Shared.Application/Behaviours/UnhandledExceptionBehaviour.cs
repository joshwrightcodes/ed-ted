using MediatR;
using Microsoft.Extensions.Logging;
// ReSharper disable ContextualLoggerProblem

namespace Ted.Shared.Application.Behaviours;

/// <summary>
/// MediatR behaviour that handles any unhandled exceptions within the MediatR pipeline.
/// </summary>
/// <typeparam name="TRequest">MediatR request type.</typeparam>
/// <typeparam name="TResponse">MediatR response type.</typeparam>
public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<TRequest> _logger;

    /// <summary>
    /// Initialises a new instance of the <see cref="UnhandledExceptionBehaviour{TRequest,TResponse}"/> class.
    /// </summary>
    /// <param name="logger">Request logger instance.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="logger"/> is null.
    /// </exception>
    public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<TResponse> Handle(
        TRequest request,
        CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogError(ex, "Unhandled Exception in Request: {Name} {@Request}", requestName, request);

            throw;
        }
    }
}