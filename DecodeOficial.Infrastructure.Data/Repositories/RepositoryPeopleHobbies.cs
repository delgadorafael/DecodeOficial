using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Repositories;
using DecodeOficial.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DecodeOficial.Infrastructure.Data.Repositories
{
    public class RepositoryPeopleHobbies : RepositoryBase<PeopleHobbies>, IRepositoryPeopleHobbies
    {
        private readonly DecodeContext _decodeContext;

        public RepositoryPeopleHobbies(DecodeContext decodeContext) : base(decodeContext)
        {
            _decodeContext = decodeContext;
        }

        public override PeopleHobbies GetById(int id)
        {
            return _decodeContext.PeopleHobbies.AsNoTracking().Where(h => h.HobbyId == id).FirstOrDefault();
        }
    }
}
