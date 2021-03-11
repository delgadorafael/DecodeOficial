using AutoMapper;
using DecodeOficial.Application.DTO;
using DecodeOficial.Application.Interfaces;
using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Servicies;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecodeOficial.Application.Servicies
{
    public class ApplicationServicePerson : IApplicationServicePerson
    {
        private readonly IServicePerson _servicePerson;
        private readonly IMapper _mapper;

        public ApplicationServicePerson(IServicePerson servicePerson, IMapper mapper)
        {
            _servicePerson = servicePerson;
            _mapper = mapper;
        }

        public void Add(PersonDTO obj)
        {
            var person = _mapper.Map<Person>(obj);
            _servicePerson.Add(person);
        }

        public IEnumerable<PersonDTO> GetAll()
        {
            var person = _servicePerson.GetAll();
            return _mapper.Map<IEnumerable<PersonDTO>>(person);
        }

        public PersonDTO GetById(int id)
        {
            var person = _servicePerson.GetById(id);
            return _mapper.Map<PersonDTO>(person);
        }

        public void Remove(PersonDTO obj)
        {
            var person = _mapper.Map<Person>(obj);
            _servicePerson.Remove(person);
        }

        public void Update(PersonDTO obj)
        {
            var person = _mapper.Map<Person>(obj);
            _servicePerson.Update(person);
        }
    }
}
