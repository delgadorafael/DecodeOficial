using AutoMapper;
using DecodeOficial.Application.Command;
using DecodeOficial.Application.DTO.Hobby;
using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Servicies;
using MediatR;

namespace DecodeOficial.Application.CommandHandler
{
    public class HobbyCreateCommandHandler : RequestHandler<HobbyCreateCommand>
    {
        private readonly IMapper _mapper;
        private readonly IServiceHobby _serviceHobby;

        public HobbyCreateCommandHandler(IMapper mapper, IServiceHobby serviceHobby)
        {
            _mapper = mapper;
            _serviceHobby = serviceHobby;
        }

        protected override void Handle(HobbyCreateCommand request)
        {
            var entity = _mapper.Map<HobbyCreateDTO, Hobby>(request.hobbyCreateDTO);
            _serviceHobby.Add(entity);
        }
    }
}
