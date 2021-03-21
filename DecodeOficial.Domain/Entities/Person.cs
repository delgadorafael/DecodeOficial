using DecodeOficial.Domain.Enumerators;
using DecodeOficial.Domain.Interfaces.Entities;
using System;

namespace DecodeOficial.Domain.Entities
{
    public class Person : Base, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ProfessionId { get; set; }
        public Profession Profession { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Hobbies { get; set; }
        public Status Status { get; set; }
        public DateTime RegisterDate { get; set; }

    }
}
