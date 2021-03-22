using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Repositories;
using DecodeOficial.Infrastructure.Data.Context;

namespace DecodeOficial.Infrastructure.Data.Repositories
{
    public class RepositoryHobby : RepositoryBase<Hobby>, IRepositoryHobby
    {
        private readonly DecodeContext _decodeContext;

        public RepositoryHobby(DecodeContext decodeContext) : base(decodeContext)
        {
            _decodeContext = decodeContext;
        }
    }
}
