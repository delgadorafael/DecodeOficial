using DecodeOficial.Application.DTO.Hobby;
using MediatR;

namespace DecodeOficial.Application.Command
{
    public class HobbyUpdateCommand : IRequest
    {
        public HobbyUpdateDTO hobbyUpdateDTO;
    }
}
