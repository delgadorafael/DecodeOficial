using DecodeOficial.Domain.Entities;
using System.Collections.Generic;

namespace DecodeOficial.Domain.Interfaces.Servicies
{
    public interface IServiceProfession : IServiceBase<Profession>
    {
        IEnumerable<Profession> SearchByRole(string search);
    }
}
