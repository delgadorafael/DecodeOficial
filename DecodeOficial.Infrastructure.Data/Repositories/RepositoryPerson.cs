using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Repositories;
using DecodeOficial.Infrastructure.Data.Context;

namespace DecodeOficial.Infrastructure.Data.Repositories
{
    public class RepositoryPerson : RepositoryBase<Person>, IRepositoryPerson
    {
        private readonly DecodeContext _decodeContext;

        public RepositoryPerson(DecodeContext decodeContext) : base(decodeContext)
        {
            _decodeContext = decodeContext;
        }
    }
}
