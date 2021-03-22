using AutoMapper;
using DecodeOficial.Application.Command;
using DecodeOficial.Application.DTO.Hobby;
using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Servicies;
using MediatR;

namespace DecodeOficial.Application.CommandHandler
{
    public class HobbyUpdateCommandHandler : RequestHandler<HobbyUpdateCommand>
    {
        private readonly IMapper _mapper;
        private readonly IServiceHobby _serviceHobby;

        public HobbyUpdateCommandHandler(IMapper mapper, IServiceHobby serviceHobby)
        {
            _mapper = mapper;
            _serviceHobby = serviceHobby;
        }

        protected override void Handle(HobbyUpdateCommand request)
        {
            var entity = _mapper.Map<HobbyUpdateDTO, Hobby>(request.hobbyUpdateDTO);
            _serviceHobby.Update(entity);
        }
    }
}
