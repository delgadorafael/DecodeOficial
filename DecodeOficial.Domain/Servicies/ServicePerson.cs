using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Repositories;
using DecodeOficial.Domain.Interfaces.Servicies;
using System.Collections.Generic;

namespace DecodeOficial.Domain.Servicies
{
    public class ServicePerson : ServiceBase<Person>, IServicePerson
    {
        private readonly IRepositoryPerson _repositoryPerson;

        public ServicePerson(IRepositoryPerson repositoryPerson) : base(repositoryPerson)
        {
            _repositoryPerson = repositoryPerson;
        }

        public IEnumerable<Person> GetPersonByProfession(int id)
        {
            return _repositoryPerson.GetPersonByProfession(id);
        }

        public IEnumerable<Person> SearchByName(string search)
        {
            return _repositoryPerson.SearchByName(search);
        }
    }
}
