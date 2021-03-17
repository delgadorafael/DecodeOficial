using DecodeOficial.Domain.Interfaces.Repositories;
using DecodeOficial.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DecodeOficial.Infrastructure.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DecodeContext _decodeContext;

        public RepositoryBase(DecodeContext decodeContext)
        {
            _decodeContext = decodeContext;
        }

        public IEnumerable<T> GetAll()
        {
            return _decodeContext.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            var _entity = _decodeContext.Set<T>().Find(id);
            if (_entity != null)
            {
                _decodeContext.Entry(_entity).State = EntityState.Detached;
            }
            return _entity;
        }
        public void Add(T obj)
        {
            _decodeContext.Set<T>().Add(obj);
            _decodeContext.SaveChanges();
        }
        public void Update(T obj)
        {
            _decodeContext.Set<T>().Update(obj);
            _decodeContext.SaveChanges();
        }
        public void Remove(T obj)
        {
            _decodeContext.Set<T>().Remove(obj);
            _decodeContext.SaveChanges();
        }
    }
}
