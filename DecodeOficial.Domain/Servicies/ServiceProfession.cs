using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Repositories;
using DecodeOficial.Domain.Interfaces.Servicies;

namespace DecodeOficial.Domain.Servicies
{
    public class ServiceProfession : ServiceBase<Profession>, IServiceProfession
    {
        private readonly IRepositoryProfession _repositoryProfession;

        public ServiceProfession(IRepositoryProfession repositoryProfession) : base(repositoryProfession)
        {
            _repositoryProfession = repositoryProfession;
        }
    }
}
