using DecodeOficial.Application.DTO.Person;
using MediatR;

namespace DecodeOficial.Application.Command
{
    public class PersonCreateCommand : IRequest
    {
        public PersonCreateDTO personCreateDTO;
    }
}
