using AutoMapper;
using DecodeOficial.Application.Command;
using DecodeOficial.Domain.Interfaces.Servicies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecodeOficial.Application.CommandHandler
{
    public class ProfessionDeleteCommandHandler : RequestHandler<ProfessionDeleteCommand>
    {
        private readonly IMapper _mapper;
        private readonly IServiceProfession _serviceProfession;

        public ProfessionDeleteCommandHandler(IMapper mapper, IServiceProfession serviceProfession)
        {
            _mapper = mapper;
            _serviceProfession = serviceProfession;
        }

        protected override void Handle(ProfessionDeleteCommand request)
        {
            var entity = _serviceProfession.GetById(request.Id);
            if (entity != null)
            {
                _serviceProfession.Remove(entity);
            }
        }
    }
}
