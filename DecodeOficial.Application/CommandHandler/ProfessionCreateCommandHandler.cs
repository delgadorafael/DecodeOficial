using AutoMapper;
using DecodeOficial.Application.Command;
using DecodeOficial.Application.DTO.Profession;
using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Servicies;
using MediatR;

namespace DecodeOficial.Application.CommandHandler
{
    public class ProfessionCreateCommandHandler : RequestHandler<ProfessionCreateCommand>
    {
        private readonly IMapper _mapper;
        private readonly IServiceProfession _serviceProfession;

        public ProfessionCreateCommandHandler(IMapper mapper, IServiceProfession serviceProfession)
        {
            _mapper = mapper;
            _serviceProfession = serviceProfession;
        }

        protected override void Handle(ProfessionCreateCommand request)
        {
            var entity = _mapper.Map<ProfessionCreateDTO, Profession>(request.professionCreateDTO);
            _serviceProfession.Add(entity);
        }
    }
}
