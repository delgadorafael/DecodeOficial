using AutoMapper;
using DecodeOficial.Application.DTO.Person;
using DecodeOficial.Application.Query;
using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Servicies;
using MediatR;
using System.Collections.Generic;

namespace DecodeOficial.Application.QueryHandler
{
    public class PersonGetAllQueryHandler : RequestHandler<PersonGetAllQuery, IEnumerable<PersonDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IServicePerson _servicePerson;

        public PersonGetAllQueryHandler(IMapper mapper, IServicePerson servicePerson)
        {
            _mapper = mapper;
            _servicePerson = servicePerson;
        }

        protected override IEnumerable<PersonDTO> Handle(PersonGetAllQuery request)
        {
            var result = _servicePerson.GetAll();
            return _mapper.Map<IEnumerable<Person>, IEnumerable<PersonDTO>>(result);
        }
    }
}
