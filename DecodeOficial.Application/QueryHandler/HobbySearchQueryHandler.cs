using AutoMapper;
using DecodeOficial.Application.DTO.Hobby;
using DecodeOficial.Application.Query;
using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Servicies;
using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace DecodeOficial.Application.QueryHandler
{
    public class HobbySearchQueryHandler : RequestHandler<HobbySearchQuery, IEnumerable<HobbyDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IServiceHobby _serviceHobby;

        public HobbySearchQueryHandler(IMapper mapper, IServiceHobby serviceHobby)
        {
            _mapper = mapper;
            _serviceHobby = serviceHobby;
        }

        protected override IEnumerable<HobbyDTO> Handle(HobbySearchQuery request)
        {
            var result = _serviceHobby.SearchByHobby(request.Search);
            return _mapper.Map<IEnumerable<Hobby>, IEnumerable<HobbyDTO>>(result);
        }
    }
}
