using DecodeOficial.Application.DTO.Hobby;
using MediatR;

namespace DecodeOficial.Application.Command
{
    public class HobbyCreateCommand : IRequest
    {
        public HobbyCreateDTO hobbyCreateDTO;
    }
}
