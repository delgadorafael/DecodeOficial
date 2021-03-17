using AutoMapper;
using DecodeOficial.Application.Command;
using DecodeOficial.Application.DTO;
using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Servicies;
using MediatR;

namespace DecodeOficial.Application.CommandHandler
{
    public class PersonUpdateCommandHandler : RequestHandler<PersonUpdateCommand>
    {
        private readonly IMapper _mapper;
        private readonly IServicePerson _servicePerson;

        public PersonUpdateCommandHandler(IMapper mapper, IServicePerson servicePerson)
        {
            _mapper = mapper;
            _servicePerson = servicePerson;
        }

        protected override void Handle(PersonUpdateCommand request)
        {
            var entity = _mapper.Map<PersonUpdateDTO, Person>(request.personUpdateDTO);
            _servicePerson.Update(entity);
        }
    }
}
