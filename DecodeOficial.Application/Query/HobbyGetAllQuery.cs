using DecodeOficial.Application.DTO.Hobby;
using MediatR;
using System.Collections.Generic;

namespace DecodeOficial.Application.Query
{
    public class HobbyGetAllQuery : IRequest<IEnumerable<HobbyDTO>>
    {
    }
}
