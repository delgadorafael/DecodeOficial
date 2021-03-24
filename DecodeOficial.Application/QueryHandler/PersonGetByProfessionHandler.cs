using AutoMapper;
using DecodeOficial.Application.DTO.Person;
using DecodeOficial.Application.Query;
using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Servicies;
using MediatR;
using System.Collections.Generic;

namespace DecodeOficial.Application.QueryHandler
{
    public class PersonGetByProfessionHandler : RequestHandler<PersonGetByProfessionQuery, IEnumerable<PersonDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IServicePerson _servicePerson;

        public PersonGetByProfessionHandler(IMapper mapper, IServicePerson servicePerson)
        {
            _mapper = mapper;
            _servicePerson = servicePerson;
        }

        protected override IEnumerable<PersonDTO> Handle(PersonGetByProfessionQuery request)
        {
            var result = _servicePerson.GetPersonByProfession(request.Id);
            return _mapper.Map<IEnumerable<Person>, IEnumerable<PersonDTO>>(result);
        }
    }
}
