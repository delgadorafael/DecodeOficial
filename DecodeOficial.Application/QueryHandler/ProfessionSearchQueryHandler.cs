using AutoMapper;
using DecodeOficial.Application.DTO.Profession;
using DecodeOficial.Application.Query;
using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Servicies;
using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace DecodeOficial.Application.QueryHandler
{
    public class ProfessionSearchQueryHandler : RequestHandler<ProfessionSearchQuery, IEnumerable<ProfessionDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IServiceProfession _serviceProfession;

        public ProfessionSearchQueryHandler(IMapper mapper, IServiceProfession serviceProfession)
        {
            _mapper = mapper;
            _serviceProfession = serviceProfession;
        }

        protected override IEnumerable<ProfessionDTO> Handle(ProfessionSearchQuery request)
        {
            var result = _serviceProfession.SearchByRole(request.search);
            return _mapper.Map<IEnumerable<Profession>, IEnumerable<ProfessionDTO>>(result);
        }
    }
}
