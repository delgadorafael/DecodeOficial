using DecodeOficial.Application.DTO.Profession;
using MediatR;
using System.Collections.Generic;

namespace DecodeOficial.Application.Query
{
    public class ProfessionSearchQuery : IRequest<IEnumerable<ProfessionDTO>>
    {
        public string search;
    }
}
