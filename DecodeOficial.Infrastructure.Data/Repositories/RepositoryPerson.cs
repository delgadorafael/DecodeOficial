using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Repositories;
using DecodeOficial.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
            return _decodeContext.People.Include(h => h.Hobbies).Include(p => p.Profession).ToList();
        }

        public override Person GetById(int id)
        {
            return _decodeContext.People.AsNoTracking().Where(p => p.Id == id).Include(p => p.Profession).Include(h => h.Hobbies).FirstOrDefault();
        }

        public override void Update(Person obj)
        {
            foreach (var hobby in obj.Hobbies)
            {
                hobby.PersonId = obj.Id;
            }

            base.Update(obj);
        }

        public IEnumerable<Person> GetPersonByProfession(int id)
        {
            return _decodeContext.People.Where(p => p.ProfessionId == id).ToList();
        }

        public IEnumerable<Person> SearchByName(string search)
        {
            return _decodeContext.People.AsQueryable()
                .Where(x => x.FirstName.ToLower().Contains(search.Trim().ToLower()) || x.LastName.ToLower().Contains(search.Trim().ToLower()))
                .Include(h => h.Hobbies)
                .Include(p => p.Profession)
                .ToList();
        }
    }
}
