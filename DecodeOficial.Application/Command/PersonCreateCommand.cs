using DecodeOficial.Application.DTO;
using MediatR;

namespace DecodeOficial.Application.Command
{
    public class PersonCreateCommand : IRequest
    {
        public PersonCreateDTO personCreateDTO;
    }
}
