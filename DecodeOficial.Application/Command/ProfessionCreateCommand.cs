using DecodeOficial.Application.DTO.Profession;
using MediatR;

namespace DecodeOficial.Application.Command
{
    public class ProfessionCreateCommand : IRequest
    {
        public ProfessionCreateDTO professionCreateDTO;
    }
}
