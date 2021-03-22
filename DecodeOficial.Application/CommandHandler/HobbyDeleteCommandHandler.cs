using AutoMapper;
using DecodeOficial.Application.Command;
using DecodeOficial.Domain.Interfaces.Servicies;
using MediatR;

namespace DecodeOficial.Application.CommandHandler
{
    public class HobbyDeleteCommandHandler : RequestHandler<HobbyDeleteCommand>
    {
        private readonly IMapper _mapper;
        private readonly IServiceHobby _serviceHobby;

        public HobbyDeleteCommandHandler(IMapper mapper, IServiceHobby serviceHobby)
        {
            _mapper = mapper;
            _serviceHobby = serviceHobby;
        }

        protected override void Handle(HobbyDeleteCommand request)
        {
            var entity = _serviceHobby.GetById(request.Id);
            if (entity != null)
            {
                _serviceHobby.Remove(entity);
            }
        }
    }
}
