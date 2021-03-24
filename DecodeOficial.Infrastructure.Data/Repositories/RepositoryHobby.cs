using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Repositories;
using DecodeOficial.Infrastructure.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace DecodeOficial.Infrastructure.Data.Repositories
{
    public class RepositoryHobby : RepositoryBase<Hobby>, IRepositoryHobby
    {
        private readonly DecodeContext _decodeContext;

        public RepositoryHobby(DecodeContext decodeContext) : base(decodeContext)
        {
            _decodeContext = decodeContext;
        }
        public IEnumerable<Hobby> SearchByHobby(string search)
        {
            return _decodeContext.Hobbies.AsQueryable()
                .Where(x => x.Name.ToLower().Contains(search.Trim().ToLower()))
                .ToList();
        }
    }
}
