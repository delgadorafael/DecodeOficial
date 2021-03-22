using DecodeOficial.Application.DTO.Profession;
using MediatR;

namespace DecodeOficial.Application.Query
{
    public class ProfessionGetByIdQuery : IRequest<ProfessionDTO>
    {
        public int Id;
    }
}
