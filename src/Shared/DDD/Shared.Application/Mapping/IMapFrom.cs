using AutoMapper;

namespace Ted.Shared.Application.Mapping;

public interface IMapFrom<T>
{
    void Mapping(Profile profile)
    {
        profile.CreateMap(typeof(T), GetType());
    }
}