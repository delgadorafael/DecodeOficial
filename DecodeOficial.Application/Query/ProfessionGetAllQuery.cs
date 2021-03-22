using DecodeOficial.Application.DTO.Profession;
using MediatR;
using System.Collections.Generic;

namespace DecodeOficial.Application.Query
{
    public class ProfessionGetAllQuery : IRequest<IEnumerable<ProfessionDTO>>
    {
    }
}
