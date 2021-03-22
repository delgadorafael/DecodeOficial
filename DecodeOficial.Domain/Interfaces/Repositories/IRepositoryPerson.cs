using DecodeOficial.Domain.Entities;
using System.Collections.Generic;

namespace DecodeOficial.Domain.Interfaces.Repositories
{
    public interface IRepositoryPerson : IRepositoryBase<Person>
    {
        IEnumerable<Person> GetByProfession(int id);
    }
}
