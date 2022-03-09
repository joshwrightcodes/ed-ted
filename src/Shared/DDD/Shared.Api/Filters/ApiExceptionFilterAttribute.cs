using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Ted.Shared.Application.Exceptions;

namespace Ted.Shared.Api.Filters;

/// <summary>
/// Api Exception Filter.
/// </summary>
public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
{
    private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

    /// <summary>
    /// Initialises a new instance of the <see cref="ApiExceptionFilterAttribute" /> class.
    /// </summary>
    public ApiExceptionFilterAttribute()
    {
        _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
        {
            {typeof(ValidationException), HandleValidationException},
            {typeof(NotFoundException), HandleNotFoundException},
            {typeof(UnauthorizedAccessException), HandleUnauthorizedAccessException},
            {typeof(ForbiddenAccessException), HandleForbiddenAccessException}
        };
    }

    /// <inheritdoc />
    public override void OnException(ExceptionContext context)
    {
        HandleException(context);

        base.OnException(context);
    }

    /// <summary>
    /// Invalid Model Exception Handler.
    /// </summary>
    /// <param name="context">Exception Context.</param>
    private static void HandleInvalidModelStateException(ExceptionContext context)
    {
        var details = new ProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
        };

        context.Result = new BadRequestObjectResult(details);

        context.ExceptionHandled = true;
    }

    /// <summary>
    /// Unknown Exception Handler.
    /// </summary>
    /// <param name="context">Exception Context.</param>
    private static void HandleUnknownException(ExceptionContext context)
    {
        var details = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "An error occurred while processing your request.",
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
        };

        context.Result = new ObjectResult(details)
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };

        context.ExceptionHandled = true;
    }

    private void HandleException(ExceptionContext context)
    {
        var type = context.Exception.GetType();

        if (_exceptionHandlers.ContainsKey(type))
        {
            _exceptionHandlers[type].Invoke(context);
            return;
        }

        if (!context.ModelState.IsValid)
        {
            HandleInvalidModelStateException(context);
            return;
        }

        HandleUnknownException(context);
    }

    /// <summary>
    /// Validation Exception Handler.
    /// </summary>
    /// <param name="context">Exception Context.</param>
    private void HandleValidationException(ExceptionContext context)
    {
        var exception = context.Exception as ValidationException;

        var details = new ValidationProblemDetails(exception.Errors)
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
        };

        context.Result = new BadRequestObjectResult(details);

        context.ExceptionHandled = true;
    }

    /// <summary>
    /// Entity Not Found Exception Handler.
    /// </summary>
    /// <param name="context">Exception Context.</param>
    private void HandleNotFoundException(ExceptionContext context)
    {
        var exception = context.Exception as NotFoundException;

        var details = new ProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
            Title = "The specified resource was not found.",
            Detail = exception.Message
        };

        context.Result = new NotFoundObjectResult(details);

        context.ExceptionHandled = true;
    }

    /// <summary>
    /// Unauthorized Access Exception Handler.
    /// </summary>
    /// <param name="context">Exception Context.</param>
    private void HandleUnauthorizedAccessException(ExceptionContext context)
    {
        var details = new ProblemDetails
        {
            Status = StatusCodes.Status401Unauthorized,
            Title = "Unauthorized",
            Type = "https://tools.ietf.org/html/rfc7235#section-3.1"
        };

        context.Result = new ObjectResult(details)
        {
            StatusCode = StatusCodes.Status401Unauthorized
        };

        context.ExceptionHandled = true;
    }

    /// <summary>
    /// Forbidden Action Exception Handler.
    /// </summary>
    /// <param name="context">Exception Context.</param>
    private void HandleForbiddenAccessException(ExceptionContext context)
    {
        var details = new ProblemDetails
        {
            Status = StatusCodes.Status403Forbidden,
            Title = "Forbidden",
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.3"
        };

        context.Result = new ObjectResult(details)
        {
            StatusCode = StatusCodes.Status403Forbidden
        };

        context.ExceptionHandled = true;
    }
}