using DecodeOficial.Domain.Enumerators;
using System;

namespace DecodeOficial.Application.DTO
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Profession { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Hobbies { get; set; }
        public Status Status { get; set; }
    }
}
