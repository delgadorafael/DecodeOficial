using AutoMapper;
using DecodeOficial.Application.DTO;
using DecodeOficial.Application.Query;
using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Servicies;
using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace DecodeOficial.Application.QueryHandler
{
    public class PersonSearchQueryHandler : RequestHandler<PersonSearchQuery, IEnumerable<PersonDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IServicePerson _servicePerson;

        public PersonSearchQueryHandler(IMapper mapper, IServicePerson servicePerson)
        {
            _mapper = mapper;
            _servicePerson = servicePerson;
        }

        protected override IEnumerable<PersonDTO> Handle(PersonSearchQuery request)
        {
            var result = _servicePerson.GetAll()
                .Where(x => x.FirstName.ToLower().Contains(request.Search.ToLower()) || 
                            x.LastName.ToLower().Contains(request.Search.ToLower()));
            return _mapper.Map< IEnumerable<Person>, IEnumerable<PersonDTO>>(result);
        }
    }
}
