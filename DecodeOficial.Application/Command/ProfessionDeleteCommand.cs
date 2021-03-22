using MediatR;

namespace DecodeOficial.Application.Command
{
    public class ProfessionDeleteCommand : IRequest
    {
        public int Id;
    }
}
