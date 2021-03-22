using AutoMapper;
using DecodeOficial.Application.DTO.Hobby;
using DecodeOficial.Application.DTO.PeopleHobbies;
using DecodeOficial.Application.DTO.Person;
using DecodeOficial.Application.DTO.Profession;
using DecodeOficial.Domain.Entities;
using System;

namespace DecodeOficial.Application.Mapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Person, PersonDTO>().ReverseMap()
                .ForMember(x => x.BirthDate, option => option.MapFrom(src => src.BirthDate.ToString("dd/MM/yyyy")));
            CreateMap<Person, PersonCreateDTO>().ReverseMap()
                .ForMember(x => x.BirthDate, option => option.MapFrom(src => (DateTime)src.BirthDate));
            CreateMap<Person, PersonUpdateDTO>().ReverseMap()
                .ForMember(x => x.BirthDate, option => option.MapFrom(src => (DateTime)src.BirthDate));
            CreateMap<Person, PersonDeleteDTO>().ReverseMap();

            CreateMap<Profession, ProfessionDTO>().ReverseMap();
            CreateMap<Profession, ProfessionCreateDTO>().ReverseMap();
            CreateMap<Profession, ProfessionUpdateDTO>().ReverseMap();
            CreateMap<Profession, ProfessionDeleteDTO>().ReverseMap();

            CreateMap<Hobby, HobbyDTO>().ReverseMap();
            CreateMap<Hobby, HobbyCreateDTO>().ReverseMap();
            CreateMap<Hobby, HobbyUpdateDTO>().ReverseMap();
            CreateMap<Hobby, HobbyDeleteDTO>().ReverseMap();

            CreateMap<PeopleHobbies, PeopleHobbiesDTO>().ReverseMap();


        }
    }
}
