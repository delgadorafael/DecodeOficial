using DecodeOficial.Application.DTO;
using MediatR;
using System.Collections.Generic;

namespace DecodeOficial.Application.Query
{
    public class PersonGetAllQuery : IRequest<IEnumerable<PersonDTO>>
    {
    }
}
