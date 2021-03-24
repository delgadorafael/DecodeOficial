using DecodeOficial.Domain.Entities;
using System.Collections.Generic;

namespace DecodeOficial.Domain.Interfaces.Repositories
{
    public interface IRepositoryHobby : IRepositoryBase<Hobby>
    {
        IEnumerable<Hobby> SearchByHobby(string search);
    }
}
