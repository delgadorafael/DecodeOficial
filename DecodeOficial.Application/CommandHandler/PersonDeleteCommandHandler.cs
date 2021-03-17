using AutoMapper;
using DecodeOficial.Application.Command;
using DecodeOficial.Domain.Interfaces.Servicies;
using MediatR;

namespace DecodeOficial.Application.CommandHandler
{
    public class PersonDeleteCommandHandler : RequestHandler<PersonDeleteCommand>
    {
        private readonly IMapper _mapper;
        private readonly IServicePerson _servicePerson;

        public PersonDeleteCommandHandler(IMapper mapper, IServicePerson servicePerson)
        {
            _mapper = mapper;
            _servicePerson = servicePerson;
        }

        protected override void Handle(PersonDeleteCommand request)
        {
            var entity = _servicePerson.GetById(request.Id);
            if (entity != null)
            {
                _servicePerson.Remove(entity);
            }
        }
    }
}
