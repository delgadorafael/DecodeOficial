using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Repositories;
using DecodeOficial.Domain.Interfaces.Servicies;
using System.Collections.Generic;

namespace DecodeOficial.Domain.Servicies
{
    public class ServiceHobby : ServiceBase<Hobby>, IServiceHobby
    {
        private readonly IRepositoryHobby _repositoryHobby;

        public ServiceHobby(IRepositoryHobby repositoryHobby) : base(repositoryHobby)
        {
            _repositoryHobby = repositoryHobby;
        }

        public IEnumerable<Hobby> SearchByHobby(string search)
        {
            return _repositoryHobby.SearchByHobby(search);
        }
    }
}
