using DecodeOficial.Domain.Enumerators;
using System;
using System.ComponentModel.DataAnnotations;

namespace DecodeOficial.Application.DTO.Person
{
    public class PersonUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Enter the first name")]
        [MaxLength(20, ErrorMessage = "First name must have at most 20 characters")]
        [MinLength(2, ErrorMessage = "First name must have at least 2 characters")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Enter the last name")]
        [MaxLength(50, ErrorMessage = "Last name must have at most 50 characters")]
        [MinLength(2, ErrorMessage = "Last name must have at least 2 characters")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Enter the profession Id")]
        public int ProfessionId { get; set; }
        
        [Required(ErrorMessage = "Enter the birth date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Enter the e-mail")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "The e-mail is invalid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter the hobbies")]
        public string Hobbies { get; set; }

        [Required(ErrorMessage = "Enter the status")]
        public Status Status { get; set; }
    }
}
