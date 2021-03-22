using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Repositories;
using DecodeOficial.Domain.Interfaces.Servicies;

namespace DecodeOficial.Domain.Servicies
{
    public class ServiceHobby : ServiceBase<Hobby>, IServiceHobby
    {
        private readonly IRepositoryHobby _repositoryHobby;

        public ServiceHobby(IRepositoryHobby repositoryHobby) : base(repositoryHobby)
        {
            _repositoryHobby = repositoryHobby;
        }
    }
}
