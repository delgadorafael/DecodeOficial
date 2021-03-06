using DecodeOficial.Domain.Entities;
using System.Collections.Generic;

namespace DecodeOficial.Domain.Interfaces.Repositories
{
    public interface IRepositoryPerson : IRepositoryBase<Person>
    {
        IEnumerable<Person> GetPersonByProfession(int id);
        IEnumerable<Person> SearchByName(string search);
    }
}
