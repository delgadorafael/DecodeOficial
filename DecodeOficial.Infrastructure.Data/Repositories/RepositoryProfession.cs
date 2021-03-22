using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Repositories;
using DecodeOficial.Infrastructure.Data.Context;

namespace DecodeOficial.Infrastructure.Data.Repositories
{
    public class RepositoryProfession : RepositoryBase<Profession>, IRepositoryProfession
    {
        private readonly DecodeContext _decodeContext;

        public RepositoryProfession(DecodeContext decodeContext) : base(decodeContext)
        {
            _decodeContext = decodeContext;
        }
    }
}
