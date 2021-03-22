using AutoMapper;
using DecodeOficial.Application.DTO.Hobby;
using DecodeOficial.Application.Query;
using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Servicies;
using MediatR;
using System.Collections.Generic;

namespace DecodeOficial.Application.QueryHandler
{
    public class HobbyGetAllQueryHandler : RequestHandler<HobbyGetAllQuery, IEnumerable<HobbyDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IServiceHobby _serviceHobby;

        public HobbyGetAllQueryHandler(IMapper mapper, IServiceHobby serviceHobby)
        {
            _mapper = mapper;
            _serviceHobby = serviceHobby;
        }

        protected override IEnumerable<HobbyDTO> Handle(HobbyGetAllQuery request)
        {
            var result = _serviceHobby.GetAll();
            return _mapper.Map<IEnumerable<Hobby>, IEnumerable<HobbyDTO>>(result);
        }
    }
}
