using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Repositories;
using DecodeOficial.Domain.Interfaces.Servicies;

namespace DecodeOficial.Domain.Servicies
{
    public class ServicePerson : ServiceBase<Person>, IServicePerson
    {
        private readonly IRepositoryPerson _repositoryPerson;

        public ServicePerson(IRepositoryPerson repositoryPerson) : base(repositoryPerson)
        {
            _repositoryPerson = repositoryPerson;
        }
    }
}
