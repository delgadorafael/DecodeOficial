using MediatR;

namespace DecodeOficial.Application.Command
{
    public class HobbyDeleteCommand : IRequest
    {
        public int Id;
    }
}
