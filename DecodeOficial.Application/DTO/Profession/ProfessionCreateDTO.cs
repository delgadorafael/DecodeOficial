using System.ComponentModel.DataAnnotations;

namespace DecodeOficial.Application.DTO.Profession
{
    public class ProfessionCreateDTO
    {
        [Required(ErrorMessage = "Enter the role")]
        [MaxLength(30, ErrorMessage = "Role must have at most 30 characters")]
        [MinLength(2, ErrorMessage = "Role must have at least 2 characters")]
        public string Role { get; set; }
    }
}
