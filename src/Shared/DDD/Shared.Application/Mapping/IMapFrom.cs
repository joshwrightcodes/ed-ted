using AutoMapper;

namespace Ted.Shared.Application.Mapping;

/// <summary>
/// Contract for defining AutoMapper rules on for a data model, removing the need for it to be defined directly in a
/// profile.
/// </summary>
/// <typeparam name="T">
/// Entity type to map from.
/// </typeparam>
public interface IMapFrom<T>
{
    /// <summary>
    /// Specifies how to map the model implementing <see cref="IMapFrom{T}"/> to <typeparamref name="T"/>. Defaults to
    /// mapping properties one to one with the entity.
    /// </summary>
    /// <param name="profile">
    /// AutoMapper profile to add the mapping to.
    /// </param>
    void Mapping(Profile profile)
    {
        profile.CreateMap(typeof(T), GetType());
    }
}