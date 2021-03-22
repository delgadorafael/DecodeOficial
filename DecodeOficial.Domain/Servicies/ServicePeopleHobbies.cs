using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Repositories;
using DecodeOficial.Domain.Interfaces.Servicies;

namespace DecodeOficial.Domain.Servicies
{
    public class ServicePeopleHobbies : ServiceBase<PeopleHobbies>, IServicePeopleHobbies
    {
        private readonly IRepositoryPeopleHobbies _repositoryPeopleHobbies;

        public ServicePeopleHobbies(IRepositoryPeopleHobbies repositoryPeopleHobbies) : base(repositoryPeopleHobbies)
        {
            _repositoryPeopleHobbies = repositoryPeopleHobbies;
        }
    }
}
