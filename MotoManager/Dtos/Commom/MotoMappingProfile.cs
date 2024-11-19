using AutoMapper;
using MotoManager.Domain.Entities;

namespace MotoManager.Dtos.Commom
{
    public class MotoMappingProfile : Profile
    {
        public MotoMappingProfile()
        {

            CreateMap<MotoDto, Motorcycle>()
                .ForMember(dest => dest.Identificador, opt => opt.MapFrom(src => src.Identificador))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Modelo))
                .ForMember(dest => dest.Plate, opt => opt.MapFrom(src => src.Placa))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Ano));

            CreateMap<Motorcycle, MotoDto>()
                .ForMember(dest => dest.Identificador, opt => opt.MapFrom(src => src.Identificador))
                .ForMember(dest => dest.Modelo, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.Placa, opt => opt.MapFrom(src => src.Plate))
                .ForMember(dest => dest.Ano, opt => opt.MapFrom(src => src.Year));
        }
    }
}
