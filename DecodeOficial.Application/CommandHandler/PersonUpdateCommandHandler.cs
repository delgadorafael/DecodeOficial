using AutoMapper;
using DecodeOficial.Application.Command;
using DecodeOficial.Application.DTO.Person;
using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Servicies;
using MediatR;

namespace DecodeOficial.Application.CommandHandler
{
    public class PersonUpdateCommandHandler : RequestHandler<PersonUpdateCommand>
    {
        private readonly IMapper _mapper;
        private readonly IServicePerson _servicePerson;
        private readonly IServicePeopleHobbies _servicePeopleHobbies;

        public PersonUpdateCommandHandler(IMapper mapper, IServicePerson servicePerson, IServicePeopleHobbies servicePeopleHobbies)
        {
            _mapper = mapper;
            _servicePerson = servicePerson;
            _servicePeopleHobbies = servicePeopleHobbies;
        }

        protected override void Handle(PersonUpdateCommand request)
        {
            var originalEntity = _servicePerson.GetById(request.personUpdateDTO.Id);
            var hobbies = originalEntity.Hobbies;
            foreach (var hobby in hobbies)
            {
                _servicePeopleHobbies.Remove(hobby);
            }

            var entity = _mapper.Map<PersonUpdateDTO, Person>(request.personUpdateDTO);
            foreach (var hobby in entity.Hobbies)
            {
                hobby.PersonId = request.personUpdateDTO.Id;
                _servicePeopleHobbies.Add(hobby);
            }

            _servicePerson.Update(entity);
        }
    }
}
