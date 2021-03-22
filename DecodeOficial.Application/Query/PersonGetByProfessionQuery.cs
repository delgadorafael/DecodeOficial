using DecodeOficial.Application.DTO.Person;
using MediatR;
using System.Collections.Generic;

namespace DecodeOficial.Application.Query
{
    public class PersonGetByProfessionQuery : IRequest<IEnumerable<PersonDTO>>
    {
        public int Id;
    }
}
