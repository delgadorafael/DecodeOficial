using DecodeOficial.Domain.Interfaces.Repositories;
using DecodeOficial.Domain.Interfaces.Servicies;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DecodeOficial.Domain.Servicies
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repositoryBase;

        public ServiceBase(IRepositoryBase<T> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public T GetById(int id)
        {
            return _repositoryBase.GetById(id);
        }
        public IEnumerable<T> GetAll()
        {
            return _repositoryBase.GetAll();
        }
        public void Add(T obj)
        {
            _repositoryBase.Add(obj);
        }
        public void Update(T obj)
        {
            _repositoryBase.Update(obj);
        }

        public void Remove(T obj)
        {
            _repositoryBase.Remove(obj);
        }
    }
}
