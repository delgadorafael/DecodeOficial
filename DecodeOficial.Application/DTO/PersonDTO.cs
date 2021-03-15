using DecodeOficial.Domain.Enumerators;
using System;
using System.ComponentModel.DataAnnotations;

namespace DecodeOficial.Application.DTO
{
    public class PersonDTO
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required] 
        public string LastName { get; set; }
        [Required] 
        public string Profession { get; set; }
        [Required] 
        public DateTime BirthDate { get; set; }
        [Required] 
        public string Email { get; set; }
        public string Hobbies { get; set; }
        [Required] 
        public Status Status { get; set; }
    }
}
