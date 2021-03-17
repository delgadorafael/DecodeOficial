using DecodeOficial.Application.DTO;
using MediatR;
using System.Collections.Generic;

namespace DecodeOficial.Application.Query
{
    public class PersonSearchQuery : IRequest<IEnumerable<PersonDTO>>
    {
        public string Search;
    }
}
