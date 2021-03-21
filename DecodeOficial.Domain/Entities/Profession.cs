using DecodeOficial.Domain.Interfaces.Entities;

namespace DecodeOficial.Domain.Entities
{
    public class Profession : Base, IEntity
    {
        public string Role { get; set; }
    }
}
