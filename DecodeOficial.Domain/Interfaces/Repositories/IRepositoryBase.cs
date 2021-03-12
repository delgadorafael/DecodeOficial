using System.Collections.Generic;
using System.Threading.Tasks;

namespace DecodeOficial.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task AddAsync(T obj);
        Task UpdateAsync(T obj);
        Task RemoveAsync(T obj);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
