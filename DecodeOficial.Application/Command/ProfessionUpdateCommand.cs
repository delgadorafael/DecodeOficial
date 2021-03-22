﻿using DecodeOficial.Application.DTO.Profession;
using MediatR;

namespace DecodeOficial.Application.Command
{
    public class ProfessionUpdateCommand : IRequest
    {
        public ProfessionUpdateDTO professionUpdateDTO;
    }
}
