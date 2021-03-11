using DecodeOficial.Domain.Interfaces.Repositories;
using DecodeOficial.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
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

        public void Add(T obj)
        {
            try
            {
                _decodeContext.Set<T>().Add(obj);
                _decodeContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return _decodeContext.Set<T>().ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public T GetById(int id)
        {
            try
            {
                return _decodeContext.Set<T>().Find(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Remove(T obj)
        {
            try
            {
                _decodeContext.Set<T>().Remove(obj);
                _decodeContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(T obj)
        {
            try
            {
                _decodeContext.Entry(obj).State = EntityState.Modified;
                _decodeContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
