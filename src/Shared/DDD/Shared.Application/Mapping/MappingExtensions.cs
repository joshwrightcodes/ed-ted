using System.Reflection;
using AutoMapper;

namespace Ted.Shared.Application.Mapping;

/// <summary>
/// Extensions for working with AutoMapper.
/// </summary>
public static class MappingExtensions
{
    /// <summary>
    /// Scans assembly for objects that implement <see cref="IMapFrom{T}"/> and adds their specific mapping profiles
    /// to the application's profile.
    /// </summary>
    /// <param name="profile">
    /// AutoMapper profile to append the new mappings to.
    /// </param>
    /// <param name="assembly">
    /// Assembly to scan for <see cref="IMapFrom{T}"/> usage.
    /// </param>
    public static void ApplyMappingsFromAssembly(this Profile profile, Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(t => t.GetInterfaces().Any(i =>
                i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
            .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);

            var methodInfo = type.GetMethod("Mapping")
                             ?? type.GetInterface("IMapFrom`1")!.GetMethod("Mapping");

            methodInfo?.Invoke(instance, new object[] {profile});
        }
    }
}