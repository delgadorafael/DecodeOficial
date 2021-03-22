using System.ComponentModel.DataAnnotations;

namespace DecodeOficial.Application.DTO.Hobby
{
    public class HobbyCreateDTO
    {
        [Required(ErrorMessage = "Enter the hobby")]
        [MaxLength(30, ErrorMessage = "Hobby must have at most 30 characters")]
        [MinLength(2, ErrorMessage = "Hobby must have at least 2 characters")]
        public string Name { get; set; }
    }
}
