using AutoMapper;
using DecodeOficial.Application.DTO.Person;
using DecodeOficial.Application.Query;
using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Servicies;
using MediatR;

namespace DecodeOficial.Application.QueryHandler
{
    public class PersonGetByIdQueryHandler : RequestHandler<PersonGetByIdQuery, PersonDTO>
    {
        private readonly IMapper _mapper;
        private readonly IServicePerson _servicePerson;

        public PersonGetByIdQueryHandler(IMapper mapper, IServicePerson servicePerson)
        {
            _mapper = mapper;
            _servicePerson = servicePerson;
        }

        protected override PersonDTO Handle(PersonGetByIdQuery request)
        {
            var result = _servicePerson.GetById(request.Id);
            return _mapper.Map<Person, PersonDTO>(result);
        }
    }
}
