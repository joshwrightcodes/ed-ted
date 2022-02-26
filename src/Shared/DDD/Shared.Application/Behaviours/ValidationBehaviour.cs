using FluentValidation;
using MediatR;
using Ted.Shared.Application.Extensions;

namespace Ted.Shared.Application.Behaviours;

/// <summary>
/// Automatically validates any request in the MediatR pipeline.
/// </summary>
/// <typeparam name="TRequest">Request type.</typeparam>
/// <typeparam name="TResponse">Response type.</typeparam>
public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    /// <summary>
    /// Initialises a new instance of the <see cref="ValidationBehaviour{TRequest,TResponse}"/> class with the specified
    /// validators for <typeparamref name="TRequest"/>.
    /// </summary>
    /// <param name="validators">
    /// Validators for <typeparamref name="TRequest"/>, can be null or empty.
    /// </param>
    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    /// <inheritdoc />
    public async Task<TResponse> Handle(TRequest request,
        CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        if (!_validators.Any()) return await next();

        await _validators.ValidateAndThrow(request, cancellationToken);

        return await next();
    }
}