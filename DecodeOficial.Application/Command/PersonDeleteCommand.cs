using MediatR;

namespace DecodeOficial.Application.Command
{
    public class PersonDeleteCommand : IRequest
    {
        public int Id;
    }
}
