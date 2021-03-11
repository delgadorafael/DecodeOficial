using AutoMapper;
using DecodeOficial.Application.DTO;
using DecodeOficial.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecodeOficial.Application.Mapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Person, PersonDTO>().ReverseMap();
        }
    }
}
