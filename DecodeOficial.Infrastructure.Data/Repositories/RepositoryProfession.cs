using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Repositories;
using DecodeOficial.Infrastructure.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace DecodeOficial.Infrastructure.Data.Repositories
{
    public class RepositoryProfession : RepositoryBase<Profession>, IRepositoryProfession
    {
        private readonly DecodeContext _decodeContext;

        public RepositoryProfession(DecodeContext decodeContext) : base(decodeContext)
        {
            _decodeContext = decodeContext;
        }

        public IEnumerable<Profession> SearchByRole(string search)
        {
            return _decodeContext.Professions.AsQueryable()
                .Where(x => x.Role.ToLower().Contains(search.Trim().ToLower()))
                .ToList(); ;
        }
    }
}
