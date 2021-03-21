using AutoMapper;
using DecodeOficial.Application.DTO.Profession;
using DecodeOficial.Application.Query;
using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Servicies;
using MediatR;

namespace DecodeOficial.Application.QueryHandler
{
    public class ProfessionGetByIdQueryHandler : RequestHandler<ProfessionGetByIdQuery, ProfessionDTO>
    {
        private readonly IMapper _mapper;
        private readonly IServiceProfession _serviceProfession;

        public ProfessionGetByIdQueryHandler(IMapper mapper, IServiceProfession serviceProfession)
        {
            _mapper = mapper;
            _serviceProfession = serviceProfession;
        }

        protected override ProfessionDTO Handle(ProfessionGetByIdQuery request)
        {
            var result = _serviceProfession.GetById(request.Id);
            return _mapper.Map<Profession, ProfessionDTO>(result);
        }
    }
}
