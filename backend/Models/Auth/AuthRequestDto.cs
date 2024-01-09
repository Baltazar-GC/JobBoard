using System.ComponentModel.DataAnnotations;

namespace backend.Models.Auth
{
    public class AuthRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [MinLength(5)]
        public string Password { get; set; } = string.Empty;
    }
}
