using DecodeOficial.Domain.Entities;
using System.Collections.Generic;

namespace DecodeOficial.Domain.Interfaces.Servicies
{
    public interface IServicePerson : IServiceBase<Person>
    {
        IEnumerable<Person> GetByProfession(int id);
    }
}
