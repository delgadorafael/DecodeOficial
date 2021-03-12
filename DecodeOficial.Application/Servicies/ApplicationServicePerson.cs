using AutoMapper;
using DecodeOficial.Application.DTO;
using DecodeOficial.Application.Interfaces;
using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Servicies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public async Task AddAsync(PersonDTO obj)
        {
            var person = _mapper.Map<Person>(obj);
            await _servicePerson.AddAsync(person);
        }

        public async Task<IEnumerable<PersonDTO>> GetAllAsync()
        {
            var person = await _servicePerson.GetAllAsync();
            return _mapper.Map<IEnumerable<PersonDTO>>(person);
        }

        public async Task<PersonDTO> GetByIdAsync(int id)
        {
            var person = await _servicePerson.GetByIdAsync(id);
            return _mapper.Map<PersonDTO>(person);
        }

        public async Task RemoveAsync(PersonDTO obj)
        {
            var person = _mapper.Map<Person>(obj);
            await _servicePerson.RemoveAsync(person);
        }

        public async Task UpdateAsync(PersonDTO obj)
        {
            var person = _mapper.Map<Person>(obj);
            await _servicePerson.UpdateAsync(person);
        }
    }
}
