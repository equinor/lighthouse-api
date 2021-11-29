using AutoMapper;
namespace Equinor.Lighthouse.Api.Query.Mappings;

public interface IMapFrom<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}
