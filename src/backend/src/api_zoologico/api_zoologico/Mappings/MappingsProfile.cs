using api_zoologico.Dtos;
using api_zoologico.Models;
using AutoMapper;

namespace api_zoologico.Mappings;

public class MappingsProfile : Profile
{
    public MappingsProfile()
    {
        CreateMap<EspeciesAnimales, EspecieDto>();
        CreateMap<Zoologicos, ZooDto>();
    }
}