using DecodeOficial.Domain.Interfaces.Repositories;
using DecodeOficial.Domain.Interfaces.Servicies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DecodeOficial.Domain.Servicies
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repositoryBase;

        public ServiceBase(IRepositoryBase<T> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task AddAsync(T obj)
        {
            await _repositoryBase.AddAsync(obj);
        }

        public async Task UpdateAsync(T obj)
        {
            await _repositoryBase.UpdateAsync(obj);
        }

        public async Task RemoveAsync(T obj)
        {
            await _repositoryBase.RemoveAsync(obj);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repositoryBase.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repositoryBase.GetByIdAsync(id);
        }
    }
}
