using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Repositories;
using DecodeOficial.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace DecodeOficial.Infrastructure.Data.Repositories
{
    public class RepositoryPerson : RepositoryBase<Person>, IRepositoryPerson
    {
        private readonly DecodeContext _decodeContext;

        public RepositoryPerson(DecodeContext decodeContext) : base(decodeContext)
        {
            _decodeContext = decodeContext;
        }

        public override IEnumerable<Person> GetAll()
        {
            return _decodeContext.People.Include(p => p.Profession).ToList();
        }

        public override Person GetById(int id)
        {
            return _decodeContext.People.AsNoTracking().Where(p => p.Id == id).Include(p => p.Profession).FirstOrDefault();
        }
    }
}
