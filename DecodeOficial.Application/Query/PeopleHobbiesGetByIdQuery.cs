using DecodeOficial.Application.DTO.PeopleHobbies;
using MediatR;

namespace DecodeOficial.Application.Query
{
    public class PeopleHobbiesGetByIdQuery : IRequest<PeopleHobbiesDTO>
    {
        public int Id;
    }
}
