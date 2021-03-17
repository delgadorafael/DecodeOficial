using DecodeOficial.Application.DTO;
using MediatR;

namespace DecodeOficial.Application.Command
{
    public class PersonUpdateCommand : IRequest
    {
        public PersonUpdateDTO personUpdateDTO;
    }
}
