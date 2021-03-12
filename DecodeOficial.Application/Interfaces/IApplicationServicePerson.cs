using DecodeOficial.Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DecodeOficial.Application.Interfaces
{
    public interface IApplicationServicePerson
    {
        Task AddAsync(PersonDTO obj);
        Task UpdateAsync(PersonDTO obj);
        Task RemoveAsync(PersonDTO obj);
        Task<IEnumerable<PersonDTO>> GetAllAsync();
        Task<PersonDTO> GetByIdAsync(int id);
    }
}
