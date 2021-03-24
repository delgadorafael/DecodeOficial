using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Repositories;
using DecodeOficial.Domain.Interfaces.Servicies;
using System.Collections.Generic;

namespace DecodeOficial.Domain.Servicies
{
    public class ServiceProfession : ServiceBase<Profession>, IServiceProfession
    {
        private readonly IRepositoryProfession _repositoryProfession;

        public ServiceProfession(IRepositoryProfession repositoryProfession) : base(repositoryProfession)
        {
            _repositoryProfession = repositoryProfession;
        }
        public IEnumerable<Profession> SearchByRole(string search)
        {
            return _repositoryProfession.SearchByRole(search);
        }
    }
}
