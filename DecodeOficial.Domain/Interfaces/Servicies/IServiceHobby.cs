using DecodeOficial.Domain.Entities;
using System.Collections.Generic;

namespace DecodeOficial.Domain.Interfaces.Servicies
{
    public interface IServiceHobby : IServiceBase<Hobby>
    {
        IEnumerable<Hobby> SearchByHobby(string search);
    }
}
