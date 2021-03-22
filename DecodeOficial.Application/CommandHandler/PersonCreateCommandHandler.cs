using AutoMapper;
using DecodeOficial.Application.Command;
using DecodeOficial.Application.DTO.Person;
using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Servicies;
using MediatR;

namespace DecodeOficial.Application.CommandHandler
{
    public class PersonCreateCommandHandler : RequestHandler<PersonCreateCommand>
    {
        private readonly IMapper _mapper;
        private readonly IServicePerson _servicePerson;

        public PersonCreateCommandHandler(IMapper mapper, IServicePerson servicePerson)
        {
            _mapper = mapper;
            _servicePerson = servicePerson;
        }

        protected override void Handle(PersonCreateCommand request)
        {
            var entity = _mapper.Map<PersonCreateDTO, Person>(request.personCreateDTO);
            _servicePerson.Add(entity);
        }
    }
}
