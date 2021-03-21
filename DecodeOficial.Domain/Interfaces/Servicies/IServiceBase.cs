using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DecodeOficial.Domain.Interfaces.Servicies
{
    public interface IServiceBase<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T obj);
        void Update(T obj);
        void Remove(T obj);
    }
}
