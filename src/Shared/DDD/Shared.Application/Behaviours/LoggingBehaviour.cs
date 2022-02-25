using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Ted.Shared.Application.Behaviours;

public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    where TRequest : notnull
{
    private readonly ICurrentUserService _currentUserService;
    private readonly ILogger _logger;

    public LoggingBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService)
    {
        _logger = logger;
        _currentUserService = currentUserService;
    }

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var userId = _currentUserService.UserId;

        _logger.LogInformation("Request: {Name} {@UserId} {@Request}",
            requestName, userId, request);
    }
}