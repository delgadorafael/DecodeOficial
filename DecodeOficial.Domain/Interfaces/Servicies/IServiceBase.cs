using System.Collections.Generic;

namespace DecodeOficial.Domain.Interfaces.Servicies
{
    public interface IServiceBase<T> where T : class
    {
        void Add(T obj);
        void Update(T obj);
        void Remove(T obj);
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
