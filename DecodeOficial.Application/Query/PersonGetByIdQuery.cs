using DecodeOficial.Application.DTO;
using MediatR;

namespace DecodeOficial.Application.Query
{
    public class PersonGetByIdQuery : IRequest<PersonDTO>
    {
        public int Id;
    }
}
