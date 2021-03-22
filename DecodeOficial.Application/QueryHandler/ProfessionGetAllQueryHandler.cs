using AutoMapper;
using DecodeOficial.Application.DTO.Profession;
using DecodeOficial.Application.Query;
using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Servicies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecodeOficial.Application.QueryHandler
{
    public class ProfessionGetAllQueryHandler : RequestHandler<ProfessionGetAllQuery, IEnumerable<ProfessionDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IServiceProfession _serviceProfession;

        public ProfessionGetAllQueryHandler(IMapper mapper, IServiceProfession serviceProfession)
        {
            _mapper = mapper;
            _serviceProfession = serviceProfession;
        }

        protected override IEnumerable<ProfessionDTO> Handle(ProfessionGetAllQuery request)
        {
            var result = _serviceProfession.GetAll();
            return _mapper.Map<IEnumerable<Profession>, IEnumerable<ProfessionDTO>>(result);
        }
    }
}
