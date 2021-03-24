using DecodeOficial.Domain.Entities;
using System.Collections.Generic;

namespace DecodeOficial.Domain.Interfaces.Servicies
{
    public interface IServicePerson : IServiceBase<Person>
    {
        IEnumerable<Person> GetPersonByProfession(int id);
        IEnumerable<Person> SearchByName(string search);
    }
}
