using DecodeOficial.Application.DTO;
using System.Collections.Generic;

namespace DecodeOficial.Application.Interfaces
{
    public interface IApplicationServicePerson
    {
        void Add(PersonDTO obj);
        void Update(PersonDTO obj);
        void Remove(PersonDTO obj);
        IEnumerable<PersonDTO> GetAll();
        PersonDTO GetById(int id);
    }
}
