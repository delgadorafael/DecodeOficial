using System.Collections.Generic;
using System.Threading.Tasks;

namespace DecodeOficial.Domain.Interfaces.Servicies
{
    public interface IServiceBase<T> where T : class
    {
        Task AddAsync(T obj);
        Task UpdateAsync(T obj);
        Task RemoveAsync(T obj);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
