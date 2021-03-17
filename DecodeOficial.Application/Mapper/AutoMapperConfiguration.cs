using AutoMapper;
using DecodeOficial.Application.DTO;
using DecodeOficial.Domain.Entities;
using System;

namespace DecodeOficial.Application.Mapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Person, PersonDTO>()
                .ReverseMap()
                .ForMember(x => x.BirthDate, option => option.MapFrom(src => src.BirthDate.ToString("dd/MM/yyyy")));
            CreateMap<Person, PersonCreateDTO>()
                .ReverseMap()
                .ForMember(x => x.BirthDate, option => option.MapFrom(src => (DateTime)src.BirthDate));
            CreateMap<Person, PersonUpdateDTO>()
                .ReverseMap()
                .ForMember(x => x.BirthDate, option => option.MapFrom(src => (DateTime)src.BirthDate)); ;
            CreateMap<Person, PersonDeleteDTO>().ReverseMap();
        }
    }
}
