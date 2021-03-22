using DecodeOficial.Domain.Interfaces.Entities;
using System.Collections.Generic;

namespace DecodeOficial.Domain.Entities
{
    public class Hobby : Base, IEntity
    {
        public string Name { get; set; }
        public IEnumerable<PeopleHobbies> People { get; set; }
    }
}
