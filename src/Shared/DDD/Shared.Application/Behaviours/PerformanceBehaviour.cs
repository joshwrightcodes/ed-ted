using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ted.Shared.Application.Behaviours;

public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IRequest<TResponse>
{
    private readonly ICurrentUserService _currentUserService;
    private readonly ILogger<TRequest> _logger;
    private readonly Stopwatch _timer;

    public PerformanceBehaviour(
        ILogger<TRequest> logger,
        ICurrentUserService currentUserService)
    {
        _timer = new Stopwatch();

        _logger = logger;
        _currentUserService = currentUserService;
    }

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