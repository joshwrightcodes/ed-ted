using System.Reflection;
using AutoMapper;
using Ted.Shared.Application.Mapping;

namespace Ted.Services.Courses.Application;

/// <summary>
/// Automapper profile.
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Initialises a new instance of the <see cref="MappingProfile" /> class and applies all AutoMapper mappings from
    /// the application where <see cref="IMapFrom{T}" /> is implemented for an object.
    /// </summary>
    public MappingProfile()
    {
        this.ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
    }
}