using DecodeOficial.Domain.Interfaces.Repositories;
using DecodeOficial.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecodeOficial.Infrastructure.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DecodeContext _decodeContext;

        public RepositoryBase(DecodeContext decodeContext)
        {
            _decodeContext = decodeContext;
        }

        public async Task AddAsync(T obj)
        {
            try
            {
                _decodeContext.Set<T>().Add(obj);
                await _decodeContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _decodeContext.Set<T>().ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                //var _context = _decodeContext.Set<T>().AsNoTracking().ToListAsync();
                var _context = _decodeContext.Set<T>().FindAsync(id);
                //_decodeContext.Entry(_context).State = EntityState.Detached;
                return await _context;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task RemoveAsync(T obj)
        {
            try
            {
                _decodeContext.Set<T>().Remove(obj);
                await _decodeContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task UpdateAsync(T obj)
        {
            try
            {
                _decodeContext.Entry(obj).State = EntityState.Modified;
                await _decodeContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
