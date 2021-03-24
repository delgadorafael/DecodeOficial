using DecodeOficial.Domain.Entities;
using System.Collections.Generic;

namespace DecodeOficial.Domain.Interfaces.Repositories
{
    public interface IRepositoryProfession : IRepositoryBase<Profession>
    {
        IEnumerable<Profession> SearchByRole(string search);
    }
}
