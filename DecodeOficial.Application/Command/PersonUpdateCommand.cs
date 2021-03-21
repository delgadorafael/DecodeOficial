using DecodeOficial.Application.DTO.Person;
using MediatR;

namespace DecodeOficial.Application.Command
{
    public class PersonUpdateCommand : IRequest
    {
        public PersonUpdateDTO personUpdateDTO;
    }
}
