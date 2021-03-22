using AutoMapper;
using DecodeOficial.Application.DTO.Hobby;
using DecodeOficial.Application.Query;
using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Servicies;
using MediatR;

namespace DecodeOficial.Application.QueryHandler
{
    public class HobbyGetByIdQueryHandler : RequestHandler<HobbyGetByIdQuery, HobbyDTO>
    {
        private readonly IMapper _mapper;
        private readonly IServiceHobby _serviceHobby;

        public HobbyGetByIdQueryHandler(IMapper mapper, IServiceHobby serviceHobby)
        {
            _mapper = mapper;
            _serviceHobby = serviceHobby;
        }

        protected override HobbyDTO Handle(HobbyGetByIdQuery request)
        {
            var result = _serviceHobby.GetById(request.Id);
            return _mapper.Map<Hobby, HobbyDTO>(result);
        }
    }
}
