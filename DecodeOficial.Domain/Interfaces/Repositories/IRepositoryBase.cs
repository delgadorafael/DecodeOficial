using System.Collections.Generic;

namespace DecodeOficial.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T obj);
        void Update(T obj);
        void Remove(T obj);
    }
}
