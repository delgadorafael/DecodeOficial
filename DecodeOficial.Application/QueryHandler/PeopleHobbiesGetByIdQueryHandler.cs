using AutoMapper;
using DecodeOficial.Application.DTO.PeopleHobbies;
using DecodeOficial.Application.Query;
using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Servicies;
using MediatR;

namespace DecodeOficial.Application.QueryHandler
{
    public class PeopleHobbiesGetByIdQueryHandler : RequestHandler<PeopleHobbiesGetByIdQuery, PeopleHobbiesDTO>
    {
        private readonly IMapper _mapper;
        private readonly IServicePeopleHobbies _servicePeopleHobbies;

        public PeopleHobbiesGetByIdQueryHandler(IMapper mapper, IServicePeopleHobbies servicePeopleHobbies)
        {
            _mapper = mapper;
            _servicePeopleHobbies = servicePeopleHobbies;
        }

        protected override PeopleHobbiesDTO Handle(PeopleHobbiesGetByIdQuery request)
        {
            var result = _servicePeopleHobbies.GetById(request.Id);
            return _mapper.Map<PeopleHobbies, PeopleHobbiesDTO>(result);
        }
    }
}
