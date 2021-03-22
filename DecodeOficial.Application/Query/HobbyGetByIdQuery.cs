using DecodeOficial.Application.DTO.Hobby;
using MediatR;

namespace DecodeOficial.Application.Query
{
    public class HobbyGetByIdQuery : IRequest<HobbyDTO>
    {
        public int Id;
    }
}
