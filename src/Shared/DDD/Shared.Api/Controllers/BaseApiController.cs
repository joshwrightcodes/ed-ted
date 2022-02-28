using System.Net.Mime;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Ted.Shared.Api.Controllers;

/// <summary>
/// Base Api Controller.
/// <para>
/// Handle shared dependencies such as Mediator.
/// </para>
/// </summary>
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
[Route("[controller]")]
public abstract class BaseApiController : ControllerBase
{
    private ISender _mediator;
    private IMapper _mapper;

    /// <summary>
    /// Gets the Mediator Service.
    /// </summary>
    protected ISender Mediator
        => _mediator ??= HttpContext.RequestServices.GetService<ISender>();

    /// <summary>
    /// Gets the Mapper Service.
    /// </summary>
    protected IMapper Mapper
        => _mapper ??= HttpContext.RequestServices.GetService<IMapper>();
}