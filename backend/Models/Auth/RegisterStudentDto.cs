using System.ComponentModel.DataAnnotations;

namespace backend.Models.Auth
{
    public class RegisterStudentDto
    {

        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Legajo { get; set; } = string.Empty;

    }
}
