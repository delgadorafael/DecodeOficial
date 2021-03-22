using AutoMapper;
using DecodeOficial.Application.Command;
using DecodeOficial.Application.DTO.Profession;
using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Servicies;
using MediatR;

namespace DecodeOficial.Application.CommandHandler
{
    public class ProfessionUpdateCommandHandler : RequestHandler<ProfessionUpdateCommand>
    {
        private readonly IMapper _mapper;
        private readonly IServiceProfession _serviceProfession;

        public ProfessionUpdateCommandHandler(IMapper mapper, IServiceProfession serviceProfession)
        {
            _mapper = mapper;
            _serviceProfession = serviceProfession;
        }

        protected override void Handle(ProfessionUpdateCommand request)
        {
            var entity = _mapper.Map<ProfessionUpdateDTO, Profession>(request.professionUpdateDTO);
            _serviceProfession.Update(entity);
        }
    }
}
